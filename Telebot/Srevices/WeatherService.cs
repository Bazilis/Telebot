using Newtonsoft.Json;
using System.Net;
using System.Text;
using Telebot.Dto;

namespace Telebot.Srevices
{
    public class WeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory= httpClientFactory;
        }

        public async Task<string> GetReport()
        {
            var client = _httpClientFactory.CreateClient("OpenWeatherApi");

            var weatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Tashkent&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}";

            var weatherRequest = new HttpRequestMessage(HttpMethod.Get, weatherUrl);

            var resultString = new StringBuilder();

            try
            {
                var weatherResponse = await client.SendAsync(weatherRequest);

                var weatherResponseStr = await weatherResponse.Content.ReadAsStringAsync();

                var weatherResponseModel = JsonConvert.DeserializeObject<CurrentWeatherApiResponseDto>(weatherResponseStr);

                var weatherDate = new DateTime(1970, 1, 1, 5, 0, 0, DateTimeKind.Local).AddSeconds(weatherResponseModel.Dt);

                resultString.AppendLine($"{weatherDate.Day}.{weatherDate.Month} {weatherDate.TimeOfDay}");
                resultString.AppendLine($"Temp ----- {weatherResponseModel.Main.Temp.ToString()}");
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

            var airPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=41.2646&lon=69.2163&appid={Environment.GetEnvironmentVariable("ApiKey")}";

            var airPollutionRequest = new HttpRequestMessage(HttpMethod.Get, airPollutionUrl);

            try
            {
                var airPollutionResponse = await client.SendAsync(airPollutionRequest);

                var airPollutionResponseStr = await airPollutionResponse.Content.ReadAsStringAsync();

                var airPollutionResponseModel = JsonConvert.DeserializeObject<CurrentAirPollutionApiResponseDto>(airPollutionResponseStr);

                var airDate = new DateTime(1970, 1, 1, 5, 0, 0, DateTimeKind.Utc).AddSeconds(airPollutionResponseModel.List[0].Dt);

                resultString.AppendLine($"{airDate.Day}.{airDate.Month} {airDate.TimeOfDay}");
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

            return resultString.ToString();
        }
    }
}
