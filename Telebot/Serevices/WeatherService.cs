using Newtonsoft.Json;
using System.Net;
using System.Text;
using Telebot.Dto;

namespace Telebot.Serevices
{
    public class WeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory= httpClientFactory;
        }

        public async Task<string> GetReport(SubscriptionDto subscription)
        {
            var client = _httpClientFactory.CreateClient("OpenWeatherApi");

            var resultString = new StringBuilder();

            await GetWeatherReport(client, subscription, resultString);
            await GetAirPollutionReport(client, subscription, resultString);

            return resultString.ToString();
        }

        private async Task GetAirPollutionReport(HttpClient client, SubscriptionDto subscription, StringBuilder resultString)
        {
            var airPollutionRequest = new HttpRequestMessage(HttpMethod.Get, subscription.AirPollutionUrl);

            try
            {
                var airPollutionResponse = await client.SendAsync(airPollutionRequest);

                var airPollutionResponseStr = await airPollutionResponse.Content.ReadAsStringAsync();

                var airPollutionResponseModel = JsonConvert.DeserializeObject<CurrentAirPollutionApiResponseDto>(airPollutionResponseStr);

                var airDate = new DateTime(1970, 1, 1, 5, 0, 0, DateTimeKind.Utc).AddSeconds(airPollutionResponseModel.List[0].Dt);

                resultString.AppendLine($"{airDate.Day}.{airDate.Month} {airDate.TimeOfDay.ToString()}");
                resultString.AppendLine($"Aqi --------- {airPollutionResponseModel.List[0].Main.Aqi.ToString()}");
                resultString.AppendLine($"Co --------- {airPollutionResponseModel.List[0].Components.Co.ToString()}");
                resultString.AppendLine($"No --------- {airPollutionResponseModel.List[0].Components.No.ToString()}");
                resultString.AppendLine($"No2 ------- {airPollutionResponseModel.List[0].Components.No2.ToString()}");
                resultString.AppendLine($"O3 --------- {airPollutionResponseModel.List[0].Components.O3.ToString()}");
                resultString.AppendLine($"So2 -------- {airPollutionResponseModel.List[0].Components.So2.ToString()}");
                resultString.AppendLine($"Pm2_5 --- {airPollutionResponseModel.List[0].Components.Pm2_5.ToString()}");
                resultString.AppendLine($"Pm10 ----- {airPollutionResponseModel.List[0].Components.Pm10.ToString()}");
                resultString.AppendLine($"Nh3 ------- {airPollutionResponseModel.List[0].Components.Nh3.ToString()}");
                resultString.AppendLine();
            }

            catch (WebException ex)
            {
                resultString.AppendLine(ex.Message);
                resultString.AppendLine();
            }
        }

        private async Task GetWeatherReport(HttpClient client, SubscriptionDto subscription, StringBuilder resultString)
        {
            var weatherRequest = new HttpRequestMessage(HttpMethod.Get, subscription.WeatherUrl);

            try
            {
                var weatherResponse = await client.SendAsync(weatherRequest);

                var weatherResponseStr = await weatherResponse.Content.ReadAsStringAsync();

                var weatherResponseModel = JsonConvert.DeserializeObject<CurrentWeatherApiResponseDto>(weatherResponseStr);

                var weatherDate = new DateTime(1970, 1, 1, 5, 0, 0, DateTimeKind.Local).AddSeconds(weatherResponseModel.Dt);

                resultString.AppendLine($"{weatherDate.Day}.{weatherDate.Month} {weatherDate.TimeOfDay.ToString()}");
                resultString.AppendLine($"Temp ----- {weatherResponseModel.Main.Temp.ToString()}");
                resultString.AppendLine($"Feels ------ {weatherResponseModel.Main.Feels_like.ToString()}");
                resultString.AppendLine($"Pres ------- {weatherResponseModel.Main.Pressure.ToString()}");
                resultString.AppendLine($"Hum ------ {weatherResponseModel.Main.Humidity.ToString()}");
                resultString.AppendLine($"Speed ---- {weatherResponseModel.Wind.Speed.ToString()}");
                resultString.AppendLine($"Deg -------- {weatherResponseModel.Wind.Deg.ToString()}");
                resultString.AppendLine($"Clouds --- {weatherResponseModel.Clouds.All.ToString()}");
                resultString.AppendLine();
            }

            catch (WebException ex)
            {
                resultString.AppendLine(ex.Message);
                resultString.AppendLine();
            }
        }
    }
}
