namespace Telebot.Dto
{
    public class UserStateDto
    {
        public long UserId { get; set; }
        public int TimeZoneOffset { get; set; }
        public UserStateEnum UserState { get; set; } = UserStateEnum.NoState;
        public string LastCommand { get; set; } = string.Empty;
        public bool IsShortMode { get; set; }
        public List<SubscriptionDto> Subscriptions { get; set; } = new();
    }
}
