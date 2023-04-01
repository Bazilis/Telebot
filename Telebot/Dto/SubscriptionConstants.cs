﻿namespace Telebot.Dto
{
    public static class SubscriptionConstants
    {
        public static List<SubscriptionDto> SubscriptionsList { get; set; } =
            new List<SubscriptionDto>
            {
                new SubscriptionDto
                {
                    City = "Berlin",
                    TimeZoneOffset = 1,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Berlin&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=52.5244&lon=13.4105&appid={Environment.GetEnvironmentVariable("ApiKey")}"
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
                    City = "Hurghada",
                    TimeZoneOffset = 3,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Hurghada&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=27.2574&lon=33.8129&appid={Environment.GetEnvironmentVariable("ApiKey")}"
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
                    City = "Jizzakh",
                    TimeZoneOffset = 5,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Jizzakh&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=40.1158&lon=67.8422&appid={Environment.GetEnvironmentVariable("ApiKey")}"
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
                    City = "Kyiv",
                    TimeZoneOffset = 3,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Kyiv&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=50.4333&lon=30.5167&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "London",
                    TimeZoneOffset = 0,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=London&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=51.5085&lon=-0.1257&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Madrid",
                    TimeZoneOffset = 1,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Madrid&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=40.4165&lon=-3.7026&appid={Environment.GetEnvironmentVariable("ApiKey")}"
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
                    City = "Minsk",
                    TimeZoneOffset = 3,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Minsk&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=53.9&lon=27.5667&appid={Environment.GetEnvironmentVariable("ApiKey")}"
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
                    City = "Nizhny Novgorod",
                    TimeZoneOffset = 3,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Nizhny%20Novgorod&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=56.3287&lon=44.002&appid={Environment.GetEnvironmentVariable("ApiKey")}"
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
                    City = "Paris",
                    TimeZoneOffset = 1,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Paris&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=48.8534&lon=2.3488&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Rome",
                    TimeZoneOffset = 1,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Rome&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=34.257&lon=-85.1647&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Sharm el Sheikh",
                    TimeZoneOffset = 2,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Sharm%20el%20Sheikh&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=27.8518&lon=34.305&appid={Environment.GetEnvironmentVariable("ApiKey")}"
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
                    City = "Tbilisi",
                    TimeZoneOffset = 4,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Tbilisi&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=41.6941&lon=44.8337&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                },
                new SubscriptionDto
                {
                    City = "Vilnius",
                    TimeZoneOffset = 2,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Vilnius&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=54.6892&lon=25.2798&appid={Environment.GetEnvironmentVariable("ApiKey")}"
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
                    City = "Wroclaw",
                    TimeZoneOffset = 2,
                    WeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Wroclaw&units=metric&appid={Environment.GetEnvironmentVariable("ApiKey")}",
                    AirPollutionUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat=51.1&lon=17.0333&appid={Environment.GetEnvironmentVariable("ApiKey")}"
                }  
            };
    }
}
