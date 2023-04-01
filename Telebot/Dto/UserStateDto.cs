namespace Telebot.Dto
{
    public class UserStateDto
    {
        public long UserId { get; set; }
        public int TimeZoneOffset { get; set; }
        public UserStateEnum UserState { get; set; } = UserStateEnum.NoState;
        public int MessageId { get; set; }
        public string LastCommand { get; set; } = string.Empty;
        public List<SubscriptionDto> Subscriptions { get; set; } = new();
    }
}
