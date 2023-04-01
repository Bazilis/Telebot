using Newtonsoft.Json;
using System.Net;
using System.Text;
using Telebot.Dto;

namespace Telebot.Services
{
    public class WeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetReport(SubscriptionDto subscription, UserStateDto userState, bool isForSubscription = false)
        {
            var client = _httpClientFactory.CreateClient("OpenWeatherApi");

            var resultString = new StringBuilder();

            await GetWeatherReport(client, subscription, userState, resultString, isForSubscription);
            await GetAirPollutionReport(client, subscription, userState, resultString, isForSubscription);

            return resultString.ToString();
        }

        private int GetTimeZoneOffset(SubscriptionDto subscription, UserStateDto userState)
        {
            return userState.TimeZoneOffset == 0 ? subscription.TimeZoneOffset : userState.TimeZoneOffset;
        }

        private async Task GetAirPollutionReport(HttpClient client, SubscriptionDto subscription, UserStateDto userState, StringBuilder resultString, bool isForSubscription)
        {
            var airPollutionRequest = new HttpRequestMessage(HttpMethod.Get, subscription.AirPollutionUrl);

            try
            {
                var airPollutionResponse = await client.SendAsync(airPollutionRequest);

                var airPollutionResponseStr = await airPollutionResponse.Content.ReadAsStringAsync();

                var airPollutionResponseModel = JsonConvert.DeserializeObject<CurrentAirPollutionApiResponseDto>(airPollutionResponseStr);

                var airDate = new DateTime(1970, 1, 1, 0, 0, 0)
                        .AddSeconds(airPollutionResponseModel.List[0].Dt)
                        .AddHours(GetTimeZoneOffset(subscription, userState));
                resultString.AppendLine($"{airDate.TimeOfDay.ToString()}");

                if (isForSubscription)
                {
                    if (subscription.LastAirPollutionApiResponse != null)
                    {
                        BuildCurrentAirPollutionReportResultString(airPollutionResponseModel, subscription.LastAirPollutionApiResponse, resultString);
                        subscription.LastAirPollutionApiResponse = airPollutionResponseModel;
                    }
                    else
                    {
                        subscription.LastAirPollutionApiResponse = airPollutionResponseModel;
                        BuildCurrentAirPollutionReportResultString(airPollutionResponseModel, subscription.LastAirPollutionApiResponse, resultString);
                    }
                }
                else
                {
                    resultString.AppendLine($"AQI --------- {airPollutionResponseModel.List[0].Main.Aqi}");
                    resultString.AppendLine($"NO2 ------- {airPollutionResponseModel.List[0].Components.No2}");
                    resultString.AppendLine($"SO2 -------- {airPollutionResponseModel.List[0].Components.So2}");
                    resultString.AppendLine($"PM2.5 ---- {airPollutionResponseModel.List[0].Components.Pm2_5}");
                    resultString.AppendLine($"PM10 ----- {airPollutionResponseModel.List[0].Components.Pm10}");
                    resultString.AppendLine($"O3 ---------- {airPollutionResponseModel.List[0].Components.O3}");
                    resultString.AppendLine($"CO --------- {airPollutionResponseModel.List[0].Components.Co}");
                    resultString.AppendLine($"NO --------- {airPollutionResponseModel.List[0].Components.No}");
                    resultString.AppendLine($"NH3 ------- {airPollutionResponseModel.List[0].Components.Nh3}");
                }
            }

            catch (WebException ex)
            {
                resultString.AppendLine(ex.Message);
                resultString.AppendLine();
            }
        }

        private async Task GetWeatherReport(HttpClient client, SubscriptionDto subscription, UserStateDto userState, StringBuilder resultString, bool isForSubscription)
        {
            var weatherRequest = new HttpRequestMessage(HttpMethod.Get, subscription.WeatherUrl);

            try
            {
                var weatherResponse = await client.SendAsync(weatherRequest);

                var weatherResponseStr = await weatherResponse.Content.ReadAsStringAsync();

                var weatherResponseModel = JsonConvert.DeserializeObject<CurrentWeatherApiResponseDto>(weatherResponseStr);

                var weatherDate = new DateTime(1970, 1, 1, 0, 0, 0)
                    .AddSeconds(weatherResponseModel.Dt)
                    .AddHours(GetTimeZoneOffset(subscription, userState));

                resultString.AppendLine($"=========>>>  {weatherDate.Day}.{weatherDate.Month}  {subscription.City}");
                resultString.AppendLine($"{weatherDate.TimeOfDay.ToString()}");

                if (isForSubscription)
                {
                    if (subscription.LastCurrentWeatherApiResponse != null)
                    {
                        BuildCurrentWeatherReportResultString(weatherResponseModel, subscription.LastCurrentWeatherApiResponse, resultString);
                        subscription.LastCurrentWeatherApiResponse = weatherResponseModel;
                    }
                    else
                    {
                        subscription.LastCurrentWeatherApiResponse = weatherResponseModel;
                        BuildCurrentWeatherReportResultString(weatherResponseModel, subscription.LastCurrentWeatherApiResponse, resultString);
                    }
                }
                else
                {
                    resultString.AppendLine($"Temp ----- {weatherResponseModel.Main.Temp}");
                    resultString.AppendLine($"Feels ------ {weatherResponseModel.Main.Feels_like}");
                    resultString.AppendLine($"Press ----- {weatherResponseModel.Main.Pressure}");
                    resultString.AppendLine($"Humid ---- {weatherResponseModel.Main.Humidity}");
                    resultString.AppendLine($"Speed ---- {weatherResponseModel.Wind.Speed}");
                    resultString.AppendLine($"Degree --- {weatherResponseModel.Wind.Deg}");
                    resultString.AppendLine($"Clouds --- {weatherResponseModel.Clouds.All}");
                    resultString.AppendLine();
                }
            }

            catch (WebException ex)
            {
                resultString.AppendLine(ex.Message);
                resultString.AppendLine();
            }
        }

        private void BuildCurrentAirPollutionReportResultString(
            CurrentAirPollutionApiResponseDto currentAirPollutionApiResponse,
            CurrentAirPollutionApiResponseDto lastCurrentAirPollutionApiResponse,
            StringBuilder resultString)
        {
            if (currentAirPollutionApiResponse.List[0].Main.Aqi > lastCurrentAirPollutionApiResponse.List[0].Main.Aqi)
                resultString.AppendLine($"AQI --------- {currentAirPollutionApiResponse.List[0].Main.Aqi}  ▲");
            else if (currentAirPollutionApiResponse.List[0].Main.Aqi == lastCurrentAirPollutionApiResponse.List[0].Main.Aqi)
                resultString.AppendLine($"AQI --------- {currentAirPollutionApiResponse.List[0].Main.Aqi}  —");
            else
                resultString.AppendLine($"AQI --------- {currentAirPollutionApiResponse.List[0].Main.Aqi}  ▼");

            if (currentAirPollutionApiResponse.List[0].Components.No2 > lastCurrentAirPollutionApiResponse.List[0].Components.No2)
                resultString.AppendLine($"NO2 ------- {currentAirPollutionApiResponse.List[0].Components.Nh3}  ▲");
            else if (currentAirPollutionApiResponse.List[0].Components.No2 == lastCurrentAirPollutionApiResponse.List[0].Components.No2)
                resultString.AppendLine($"NO2 ------- {currentAirPollutionApiResponse.List[0].Components.No2}  —");
            else
                resultString.AppendLine($"NO2 ------- {currentAirPollutionApiResponse.List[0].Components.No2}  ▼");

            if (currentAirPollutionApiResponse.List[0].Components.So2 > lastCurrentAirPollutionApiResponse.List[0].Components.So2)
                resultString.AppendLine($"SO2 -------- {currentAirPollutionApiResponse.List[0].Components.So2}  ▲");
            else if (currentAirPollutionApiResponse.List[0].Components.So2 == lastCurrentAirPollutionApiResponse.List[0].Components.So2)
                resultString.AppendLine($"SO2 -------- {currentAirPollutionApiResponse.List[0].Components.So2}  —");
            else
                resultString.AppendLine($"SO2 -------- {currentAirPollutionApiResponse.List[0].Components.So2}  ▼");

            if (currentAirPollutionApiResponse.List[0].Components.Pm2_5 > lastCurrentAirPollutionApiResponse.List[0].Components.Pm2_5)
                resultString.AppendLine($"PM2.5 ---- {currentAirPollutionApiResponse.List[0].Components.Pm2_5}  ▲");
            else if (currentAirPollutionApiResponse.List[0].Components.Pm2_5 == lastCurrentAirPollutionApiResponse.List[0].Components.Pm2_5)
                resultString.AppendLine($"PM2.5 ---- {currentAirPollutionApiResponse.List[0].Components.Pm2_5}  —");
            else
                resultString.AppendLine($"PM2.5 ---- {currentAirPollutionApiResponse.List[0].Components.Pm2_5}  ▼");

            if (currentAirPollutionApiResponse.List[0].Components.Pm10 > lastCurrentAirPollutionApiResponse.List[0].Components.Pm10)
                resultString.AppendLine($"PM10 ----- {currentAirPollutionApiResponse.List[0].Components.Pm10}  ▲");
            else if (currentAirPollutionApiResponse.List[0].Components.Pm10 == lastCurrentAirPollutionApiResponse.List[0].Components.Pm10)
                resultString.AppendLine($"PM10 ----- {currentAirPollutionApiResponse.List[0].Components.Pm10}  —");
            else
                resultString.AppendLine($"PM10 ----- {currentAirPollutionApiResponse.List[0].Components.Pm10}  ▼");

            if (currentAirPollutionApiResponse.List[0].Components.O3 > lastCurrentAirPollutionApiResponse.List[0].Components.O3)
                resultString.AppendLine($"O3 ---------- {currentAirPollutionApiResponse.List[0].Components.O3}  ▲");
            else if (currentAirPollutionApiResponse.List[0].Components.O3 == lastCurrentAirPollutionApiResponse.List[0].Components.O3)
                resultString.AppendLine($"O3 ---------- {currentAirPollutionApiResponse.List[0].Components.O3}  —");
            else
                resultString.AppendLine($"O3 ---------- {currentAirPollutionApiResponse.List[0].Components.O3}  ▼");

            if (currentAirPollutionApiResponse.List[0].Components.Co > lastCurrentAirPollutionApiResponse.List[0].Components.Co)
                resultString.AppendLine($"CO --------- {currentAirPollutionApiResponse.List[0].Components.Co}  ▲");
            else if (currentAirPollutionApiResponse.List[0].Components.Co == lastCurrentAirPollutionApiResponse.List[0].Components.Co)
                resultString.AppendLine($"CO --------- {currentAirPollutionApiResponse.List[0].Components.Co}  —");
            else
                resultString.AppendLine($"CO --------- {currentAirPollutionApiResponse.List[0].Components.Co}  ▼");

            if (currentAirPollutionApiResponse.List[0].Components.No > lastCurrentAirPollutionApiResponse.List[0].Components.No)
                resultString.AppendLine($"NO --------- {currentAirPollutionApiResponse.List[0].Components.No}  ▲");
            else if (currentAirPollutionApiResponse.List[0].Components.No == lastCurrentAirPollutionApiResponse.List[0].Components.No)
                resultString.AppendLine($"NO --------- {currentAirPollutionApiResponse.List[0].Components.No}  —");
            else
                resultString.AppendLine($"NO --------- {currentAirPollutionApiResponse.List[0].Components.No}  ▼");

            if (currentAirPollutionApiResponse.List[0].Components.Nh3 > lastCurrentAirPollutionApiResponse.List[0].Components.Nh3)
                resultString.AppendLine($"NH3 ------- {currentAirPollutionApiResponse.List[0].Components.Nh3}  ▲");
            else if (currentAirPollutionApiResponse.List[0].Components.Nh3 == lastCurrentAirPollutionApiResponse.List[0].Components.Nh3)
                resultString.AppendLine($"NH3 ------- {currentAirPollutionApiResponse.List[0].Components.Nh3}  —");
            else
                resultString.AppendLine($"NH3 ------- {currentAirPollutionApiResponse.List[0].Components.Nh3}  ▼");
        }

        private void BuildCurrentWeatherReportResultString(
            CurrentWeatherApiResponseDto currentWeatherApiResponse,
            CurrentWeatherApiResponseDto lastCurrentWeatherApiResponse,
            StringBuilder resultString)
        {
            if (currentWeatherApiResponse.Main.Temp > lastCurrentWeatherApiResponse.Main.Temp)
                resultString.AppendLine($"Temp ----- {Math.Round(currentWeatherApiResponse.Main.Temp)}  ▲");
            else if (currentWeatherApiResponse.Main.Temp == lastCurrentWeatherApiResponse.Main.Temp)
                resultString.AppendLine($"Temp ----- {Math.Round(currentWeatherApiResponse.Main.Temp)}  —");
            else
                resultString.AppendLine($"Temp ----- {Math.Round(currentWeatherApiResponse.Main.Temp)}  ▼");

            if (currentWeatherApiResponse.Main.Feels_like > lastCurrentWeatherApiResponse.Main.Feels_like)
                resultString.AppendLine($"Feels ------ {currentWeatherApiResponse.Main.Feels_like}  ▲");
            else if (currentWeatherApiResponse.Main.Feels_like == lastCurrentWeatherApiResponse.Main.Feels_like)
                resultString.AppendLine($"Feels ------ {currentWeatherApiResponse.Main.Feels_like}  —");
            else
                resultString.AppendLine($"Feels ------ {currentWeatherApiResponse.Main.Feels_like}  ▼");

            if (currentWeatherApiResponse.Main.Pressure > lastCurrentWeatherApiResponse.Main.Pressure)
                resultString.AppendLine($"Press ----- {currentWeatherApiResponse.Main.Pressure}  ▲");
            else if (currentWeatherApiResponse.Main.Pressure == lastCurrentWeatherApiResponse.Main.Pressure)
                resultString.AppendLine($"Press ----- {currentWeatherApiResponse.Main.Pressure}  —");
            else
                resultString.AppendLine($"Press ----- {currentWeatherApiResponse.Main.Pressure}  ▼");

            if (currentWeatherApiResponse.Main.Humidity > lastCurrentWeatherApiResponse.Main.Humidity)
                resultString.AppendLine($"Humid ---- {currentWeatherApiResponse.Main.Humidity}  ▲");
            else if (currentWeatherApiResponse.Main.Humidity == lastCurrentWeatherApiResponse.Main.Humidity)
                resultString.AppendLine($"Humid ---- {currentWeatherApiResponse.Main.Humidity}  —");
            else
                resultString.AppendLine($"Humid ---- {currentWeatherApiResponse.Main.Humidity}  ▼");

            if (currentWeatherApiResponse.Wind.Speed > lastCurrentWeatherApiResponse.Wind.Speed)
                resultString.AppendLine($"Speed ---- {currentWeatherApiResponse.Wind.Speed}  ▲");
            else if (currentWeatherApiResponse.Wind.Speed == lastCurrentWeatherApiResponse.Wind.Speed)
                resultString.AppendLine($"Speed ---- {currentWeatherApiResponse.Wind.Speed}  —");
            else
                resultString.AppendLine($"Speed ---- {currentWeatherApiResponse.Wind.Speed}  ▼");

            if (currentWeatherApiResponse.Wind.Deg > lastCurrentWeatherApiResponse.Wind.Deg)
                resultString.AppendLine($"Degree --- {currentWeatherApiResponse.Wind.Deg}  ▲");
            else if (currentWeatherApiResponse.Wind.Deg == lastCurrentWeatherApiResponse.Wind.Deg)
                resultString.AppendLine($"Degree --- {currentWeatherApiResponse.Wind.Deg}  —");
            else
                resultString.AppendLine($"Degree --- {currentWeatherApiResponse.Wind.Deg}  ▼");

            if (currentWeatherApiResponse.Clouds.All > lastCurrentWeatherApiResponse.Clouds.All)
                resultString.AppendLine($"Clouds --- {currentWeatherApiResponse.Clouds.All}  ▲");
            else if (currentWeatherApiResponse.Clouds.All == lastCurrentWeatherApiResponse.Clouds.All)
                resultString.AppendLine($"Clouds --- {currentWeatherApiResponse.Clouds.All}  —");
            else
                resultString.AppendLine($"Clouds --- {currentWeatherApiResponse.Clouds.All}  ▼");

            resultString.AppendLine();
        }
    }
}
