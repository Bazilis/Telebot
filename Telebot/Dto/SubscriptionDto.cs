namespace Telebot.Dto
{
    public class SubscriptionDto
    {
        public string? City { get; set; }
        public string? WeatherUrl { get; set; }
        public string? AirPollutionUrl { get; set; }
        public List<long> SubscribersList { get; set; } = new();
    }
}
