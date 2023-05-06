using System.Collections.Concurrent;
using Telebot.Dto;

namespace Telebot.Constants
{
    public static class SubscriptionConstants
    {
        public static ConcurrentBag<SubscriptionDto> SubscriptionsList { get; set; } =
            new ConcurrentBag<SubscriptionDto>(new []
            {
                new SubscriptionDto
                {
                    City = "Wroclaw",
                    TimeZoneOffset = 2,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Wroclaw&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=51.1&lon=17.0333&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Warsaw",
                    TimeZoneOffset = 2,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Warsaw&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=52.2298&lon=21.0118&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Vilnius",
                    TimeZoneOffset = 3,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Vilnius&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=54.6892&lon=25.2798&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Toulon",
                    TimeZoneOffset = 2,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Toulon&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=43.1167&lon=5.9333&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Tbilisi",
                    TimeZoneOffset = 4,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Tbilisi&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=41.6941&lon=44.8337&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Tashkent",
                    TimeZoneOffset = 5,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Tashkent&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=41.2646&lon=69.2163&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Sharm el Sheikh",
                    TimeZoneOffset = 3,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Sharm%20el%20Sheikh&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=27.8518&lon=34.305&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Rome",
                    TimeZoneOffset = 2,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Rome&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=34.257&lon=-85.1647&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Pinsk",
                    TimeZoneOffset = 3,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Pinsk&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=52.1229&lon=26.0951&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Paris",
                    TimeZoneOffset = 2,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Paris&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=48.8534&lon=2.3488&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Odesa",
                    TimeZoneOffset = 3,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Odesa&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=46.4775&lon=30.7326&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Nicosia",
                    TimeZoneOffset = 3,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Nicosia&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=35.1667&lon=33.3667&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Minsk",
                    TimeZoneOffset = 3,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Minsk&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=53.9&lon=27.5667&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Milan",
                    TimeZoneOffset = 2,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Milan&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=45.4643&lon=9.1895&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Madrid",
                    TimeZoneOffset = 2,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Madrid&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=40.4165&lon=-3.7026&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "London",
                    TimeZoneOffset = 1,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=London&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=51.5085&lon=-0.1257&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Kyiv",
                    TimeZoneOffset = 3,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Kyiv&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=50.4333&lon=30.5167&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Kaliningrad",
                    TimeZoneOffset = 2,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Kaliningrad&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=54.7065&lon=20.511&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Jizzakh",
                    TimeZoneOffset = 5,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Jizzakh&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=40.1158&lon=67.8422&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Istanbul",
                    TimeZoneOffset = 3,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Istanbul&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=41.0351&lon=28.9833&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Hurghada",
                    TimeZoneOffset = 3,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Hurghada&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=27.2574&lon=33.8129&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Gomel",
                    TimeZoneOffset = 3,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Gomel&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=52.4345&lon=30.9754&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Bialystok",
                    TimeZoneOffset = 2,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Bialystok&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=53.1333&lon=23.15&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Berlin",
                    TimeZoneOffset = 2,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Berlin&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=52.5244&lon=13.4105&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
            });
    }
}
