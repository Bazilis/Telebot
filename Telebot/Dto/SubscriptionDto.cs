namespace Telebot.Dto
{
    public class SubscriptionDto
    {
        public string? City { get; set; }
        public int TimeZoneOffset { get; set; }
        public string? WeatherUrl { get; set; }
        public string? AirPollutionUrl { get; set; }
    }
}
