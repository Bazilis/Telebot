namespace Telebot.Dto
{
    public class UserDto
    {
        public long UserId { get; set; }
        public int TimeZoneOffset { get; set; }
        public List<SubscriptionDto> Subscriptions { get; set; } = new();
    }
}
