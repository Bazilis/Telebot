namespace Telebot.Dto
{
    public class SubscriptionDto
    {
        public string? City { get; set; }
        public int TimeZoneOffset { get; set; }
        public string? WeatherUrl { get; set; }
        public string? AirPollutionUrl { get; set; }
        public int FirstMessageId { get; set; }
        public int SecondMessageId { get; set; }
        public double TempDaySum { get; set; }
        public int HourCounter { get; set; }
        internal CurrentAirPollutionApiResponseDto? LastAirPollutionApiResponse { get; set; }
        internal CurrentWeatherApiResponseDto? LastCurrentWeatherApiResponse { get; set; }
    }
}
