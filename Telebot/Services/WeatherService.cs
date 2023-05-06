using Newtonsoft.Json;
using System.Globalization;
using System.Text;
using Telebot.Dto;
using static Telebot.Constants.AirWeatherConstants;

namespace Telebot.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("OpenWeatherApi");
        }

        public async Task<string> GetReport(SubscriptionDto subscription, UserStateDto userState, bool isForSubscription = false)
        {
            var resultString = new StringBuilder();

            await GetWeatherReport(subscription, userState, resultString, isForSubscription);
            await GetAirPollutionReport(subscription, userState, resultString, isForSubscription);

            return resultString.ToString();
        }

        private int GetTimeZoneOffset(SubscriptionDto subscription, UserStateDto userState)
        {
            return userState.TimeZoneOffset == 0 ? subscription.TimeZoneOffset : userState.TimeZoneOffset;
        }

        private async Task GetAirPollutionReport(SubscriptionDto subscription, UserStateDto userState, StringBuilder resultString, bool isForSubscription)
        {
            try
            {
                var airPollutionResponse = await _httpClient.GetAsync(subscription.AirPollutionUrl);
                airPollutionResponse.EnsureSuccessStatusCode();

                var airPollutionResponseBody = await airPollutionResponse.Content.ReadAsStringAsync();

                var airPollutionResponseModel = JsonConvert.DeserializeObject<CurrentAirPollutionApiResponseDto>(airPollutionResponseBody);

                var timeZoneOffset = GetTimeZoneOffset(subscription, userState);
                var airDate = DateTimeOffset.FromUnixTimeSeconds(airPollutionResponseModel.List[0].Dt).AddHours(timeZoneOffset);

                resultString.AppendLine();
                resultString.AppendLine($"{airDate.TimeOfDay}");

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
                    resultString.AppendLine($"{AirStringParams[0]} {airPollutionResponseModel.List[0].Main.Aqi}");
                    resultString.AppendLine($"{AirStringParams[1]} {airPollutionResponseModel.List[0].Components.No2}");
                    resultString.AppendLine($"{AirStringParams[2]} {airPollutionResponseModel.List[0].Components.So2}");
                    resultString.AppendLine($"{AirStringParams[3]} {airPollutionResponseModel.List[0].Components.Pm2_5}");
                    resultString.AppendLine($"{AirStringParams[4]} {airPollutionResponseModel.List[0].Components.Pm10}");
                    resultString.AppendLine($"{AirStringParams[5]} {airPollutionResponseModel.List[0].Components.O3}");
                    resultString.AppendLine($"{AirStringParams[6]} {airPollutionResponseModel.List[0].Components.Co}");
                    resultString.AppendLine($"{AirStringParams[7]} {airPollutionResponseModel.List[0].Components.No}");
                    resultString.AppendLine($"{AirStringParams[8]} {airPollutionResponseModel.List[0].Components.Nh3}");
                }
            }
            catch (HttpRequestException ex)
            {
                resultString.AppendLine($"Error: {ex.Message}");
                resultString.AppendLine();
            }
        }

        private async Task GetWeatherReport(SubscriptionDto subscription, UserStateDto userState, StringBuilder resultString, bool isForSubscription)
        {
            try
            {
                var weatherResponse = await _httpClient.GetAsync(subscription.WeatherUrl);
                weatherResponse.EnsureSuccessStatusCode();

                var weatherResponseBody = await weatherResponse.Content.ReadAsStringAsync();

                var weatherResponseModel = JsonConvert.DeserializeObject<CurrentWeatherApiResponseDto>(weatherResponseBody);

                var timeZoneOffset = GetTimeZoneOffset(subscription, userState);
                var weatherDate = DateTimeOffset.FromUnixTimeSeconds(weatherResponseModel.Dt).AddHours(timeZoneOffset);

                resultString.AppendLine($"=========>>>  {weatherDate.Day}.{weatherDate.Month}  {subscription.City}");
                resultString.AppendLine($"{weatherDate.TimeOfDay}");

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

                    if (weatherDate.Hour != 0)
                    {
                        subscription.TempDaySum += weatherResponseModel.Main.Temp;
                        subscription.HourCounter++;
                    }
                    else
                    {
                        if(subscription.HourCounter != 0)
                            resultString.AppendLine($"{WeatherStringParams[7]} {(subscription.TempDaySum / subscription.HourCounter).ToString("F", CultureInfo.InvariantCulture)}");
                        subscription.TempDaySum = weatherResponseModel.Main.Temp;
                        subscription.HourCounter = 1;
                    }
                }
                else
                {
                    resultString.AppendLine($"{WeatherStringParams[0]} {weatherResponseModel.Main.Temp}");
                    resultString.AppendLine($"{WeatherStringParams[1]} {weatherResponseModel.Main.Feels_like}");
                    resultString.AppendLine($"{WeatherStringParams[2]} {weatherResponseModel.Main.Pressure}");
                    resultString.AppendLine($"{WeatherStringParams[3]} {weatherResponseModel.Main.Humidity}");
                    resultString.AppendLine($"{WeatherStringParams[4]} {weatherResponseModel.Wind.Speed}");
                    resultString.AppendLine($"{WeatherStringParams[5]} {weatherResponseModel.Wind.Deg}");
                    resultString.AppendLine($"{WeatherStringParams[6]} {weatherResponseModel.Clouds.All}");
                }
            }
            catch (HttpRequestException ex)
            {
                resultString.AppendLine($"Error: {ex.Message}");
                resultString.AppendLine();
            }
        }

        private void BuildCurrentAirPollutionReportResultString(
            CurrentAirPollutionApiResponseDto currentAirPollutionApiResponse,
            CurrentAirPollutionApiResponseDto lastCurrentAirPollutionApiResponse,
            StringBuilder resultString)
        {
            char symbol = currentAirPollutionApiResponse.List[0].Main.Aqi > lastCurrentAirPollutionApiResponse.List[0].Main.Aqi ? UP : currentAirPollutionApiResponse.List[0].Main.Aqi == lastCurrentAirPollutionApiResponse.List[0].Main.Aqi ? LINE : DOWN;
            resultString.AppendLine($"{AirStringParams[0]} {currentAirPollutionApiResponse.List[0].Main.Aqi}  {symbol}");

            symbol = currentAirPollutionApiResponse.List[0].Components.No2 > lastCurrentAirPollutionApiResponse.List[0].Components.No2 ? UP : currentAirPollutionApiResponse.List[0].Components.No2 == lastCurrentAirPollutionApiResponse.List[0].Components.No2 ? LINE : DOWN;
            resultString.AppendLine($"{AirStringParams[1]} {currentAirPollutionApiResponse.List[0].Components.No2}  {symbol}");

            symbol = currentAirPollutionApiResponse.List[0].Components.So2 > lastCurrentAirPollutionApiResponse.List[0].Components.So2 ? UP : currentAirPollutionApiResponse.List[0].Components.So2 == lastCurrentAirPollutionApiResponse.List[0].Components.So2 ? LINE : DOWN;
            resultString.AppendLine($"{AirStringParams[2]} {currentAirPollutionApiResponse.List[0].Components.So2}  {symbol}");

            symbol = currentAirPollutionApiResponse.List[0].Components.Pm2_5 > lastCurrentAirPollutionApiResponse.List[0].Components.Pm2_5 ? UP : currentAirPollutionApiResponse.List[0].Components.Pm2_5 == lastCurrentAirPollutionApiResponse.List[0].Components.Pm2_5 ? LINE : DOWN;
            resultString.AppendLine($"{AirStringParams[3]} {currentAirPollutionApiResponse.List[0].Components.Pm2_5}  {symbol}");

            symbol = currentAirPollutionApiResponse.List[0].Components.Pm10 > lastCurrentAirPollutionApiResponse.List[0].Components.Pm10 ? UP : currentAirPollutionApiResponse.List[0].Components.Pm10 == lastCurrentAirPollutionApiResponse.List[0].Components.Pm10 ? LINE : DOWN;
            resultString.AppendLine($"{AirStringParams[4]} {currentAirPollutionApiResponse.List[0].Components.Pm10}  {symbol}");

            symbol = currentAirPollutionApiResponse.List[0].Components.O3 > lastCurrentAirPollutionApiResponse.List[0].Components.O3 ? UP : currentAirPollutionApiResponse.List[0].Components.O3 == lastCurrentAirPollutionApiResponse.List[0].Components.O3 ? LINE : DOWN;
            resultString.AppendLine($"{AirStringParams[5]} {currentAirPollutionApiResponse.List[0].Components.O3}  {symbol}");

            symbol = currentAirPollutionApiResponse.List[0].Components.Co > lastCurrentAirPollutionApiResponse.List[0].Components.Co ? UP : currentAirPollutionApiResponse.List[0].Components.Co == lastCurrentAirPollutionApiResponse.List[0].Components.Co ? LINE : DOWN;
            resultString.AppendLine($"{AirStringParams[6]} {currentAirPollutionApiResponse.List[0].Components.Co}  {symbol}");

            symbol = currentAirPollutionApiResponse.List[0].Components.No > lastCurrentAirPollutionApiResponse.List[0].Components.No ? UP : currentAirPollutionApiResponse.List[0].Components.No == lastCurrentAirPollutionApiResponse.List[0].Components.No ? LINE : DOWN;
            resultString.AppendLine($"{AirStringParams[7]} {currentAirPollutionApiResponse.List[0].Components.No}  {symbol}");

            symbol = currentAirPollutionApiResponse.List[0].Components.Nh3 > lastCurrentAirPollutionApiResponse.List[0].Components.Nh3 ? UP : currentAirPollutionApiResponse.List[0].Components.Nh3 == lastCurrentAirPollutionApiResponse.List[0].Components.Nh3 ? LINE : DOWN;
            resultString.AppendLine($"{AirStringParams[8]} {currentAirPollutionApiResponse.List[0].Components.Nh3}  {symbol}");
        }

        private void BuildCurrentWeatherReportResultString(
            CurrentWeatherApiResponseDto currentWeatherApiResponse,
            CurrentWeatherApiResponseDto lastCurrentWeatherApiResponse,
            StringBuilder resultString)
        {
            char symbol = currentWeatherApiResponse.Main.Temp > lastCurrentWeatherApiResponse.Main.Temp ? UP : currentWeatherApiResponse.Main.Temp == lastCurrentWeatherApiResponse.Main.Temp ? LINE : DOWN;
            resultString.AppendLine($"{WeatherStringParams[0]} {Math.Round(currentWeatherApiResponse.Main.Temp)}  {symbol}");

            symbol = currentWeatherApiResponse.Main.Feels_like > lastCurrentWeatherApiResponse.Main.Feels_like ? UP : currentWeatherApiResponse.Main.Feels_like == lastCurrentWeatherApiResponse.Main.Feels_like ? LINE : DOWN;
            resultString.AppendLine($"{WeatherStringParams[1]} {currentWeatherApiResponse.Main.Feels_like}  {symbol}");

            symbol = currentWeatherApiResponse.Main.Pressure > lastCurrentWeatherApiResponse.Main.Pressure ? UP : currentWeatherApiResponse.Main.Pressure == lastCurrentWeatherApiResponse.Main.Pressure ? LINE : DOWN;
            resultString.AppendLine($"{WeatherStringParams[2]} {currentWeatherApiResponse.Main.Pressure}  {symbol}");

            symbol = currentWeatherApiResponse.Main.Humidity > lastCurrentWeatherApiResponse.Main.Humidity ? UP : currentWeatherApiResponse.Main.Humidity == lastCurrentWeatherApiResponse.Main.Humidity ? LINE : DOWN;
            resultString.AppendLine($"{WeatherStringParams[3]} {currentWeatherApiResponse.Main.Humidity}  {symbol}");

            symbol = currentWeatherApiResponse.Wind.Speed > lastCurrentWeatherApiResponse.Wind.Speed ? UP : currentWeatherApiResponse.Wind.Speed == lastCurrentWeatherApiResponse.Wind.Speed ? LINE : DOWN;
            resultString.AppendLine($"{WeatherStringParams[4]} {currentWeatherApiResponse.Wind.Speed}  {symbol}");

            symbol = currentWeatherApiResponse.Wind.Deg > lastCurrentWeatherApiResponse.Wind.Deg ? UP : currentWeatherApiResponse.Wind.Deg == lastCurrentWeatherApiResponse.Wind.Deg ? LINE : DOWN;
            resultString.AppendLine($"{WeatherStringParams[5]} {currentWeatherApiResponse.Wind.Deg}  {symbol}");

            symbol = currentWeatherApiResponse.Clouds.All > lastCurrentWeatherApiResponse.Clouds.All ? UP : currentWeatherApiResponse.Clouds.All == lastCurrentWeatherApiResponse.Clouds.All ? LINE : DOWN;
            resultString.AppendLine($"{WeatherStringParams[6]} {currentWeatherApiResponse.Clouds.All}  {symbol}");
        }
    }
}
