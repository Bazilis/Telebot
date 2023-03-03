namespace Telebot.Dto
{
    public static class SubscriptionConstants
    {
        public static List<SubscriptionDto> SubscriptionsList { get; set; } =
            new List<SubscriptionDto>
            {
                new SubscriptionDto
                {
                    City = "Berlin",
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Berlin&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=52.5244&lon=13.4105&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Gomel",
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Gomel&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=52.4345&lon=30.9754&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Jizzakh",
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Jizzakh&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=40.1158&lon=67.8422&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Kyiv",
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Kyiv&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=50.4333&lon=30.5167&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "London",
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=London&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=51.5085&lon=-0.1257&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Madrid",
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Madrid&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=40.4165&lon=-3.7026&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Minsk",
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Minsk&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=53.9&lon=27.5667&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Odesa",
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Odesa&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=46.4775&lon=30.7326&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Paris",
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Paris&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=48.8534&lon=2.3488&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Rome",
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Rome&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=34.257&lon=-85.1647&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Tashkent",
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Tashkent&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=41.2646&lon=69.2163&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Vilnius",
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Vilnius&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=54.6892&lon=25.2798&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Warsaw",
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Warsaw&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=52.2298&lon=21.0118&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Wroclaw",
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Wroclaw&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=51.1&lon=17.0333&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },  
            };
    }
}
