using Telebot.Dto;

namespace Telebot.Services
{
    public class UserService
    {
        public List<UserDto> Users { get; set; } = new();

        public string SetResetUserTimeZoneOffset(long userId, int offset)
        {
            var user = Users.FirstOrDefault(u => u.UserId == userId);

            if (user == default)
            {
                Users.Add(new UserDto
                {
                    UserId = userId,
                    TimeZoneOffset = offset
                });

                return $"Welcome, time zone set to {offset}";
            }

            if (user.TimeZoneOffset == offset)
            {
                user.TimeZoneOffset = 0;
                return $"Time zone reset";
            }
            else
            {
                user.TimeZoneOffset = offset;
                return $"Time zone set to {offset}";
            }
        }

        public string SubscribeUnsubscribeUser(long userId, string city)
        {
            var subscription = SubscriptionConstants.SubscriptionsList.FirstOrDefault(s => s.City == city);

            if (subscription == default) return "Сity not found";

            var user = Users.FirstOrDefault(u => u.UserId == userId);

            if (user == default)
            {
                Users.Add(new UserDto
                {
                    UserId = userId,
                    Subscriptions = new List<SubscriptionDto> { subscription }
                });

                return $"Welcome, you subscribed to {subscription.City}";
            }

            var userSubscription = user.Subscriptions.FirstOrDefault(s => s.City == city);

            if (userSubscription == default)
            {
                user.Subscriptions.Add(subscription);
                return $"You subscribed to {subscription.City}";
            }
            else
            {
                user.Subscriptions.Remove(userSubscription);
                return $"You unsubscribed from {subscription.City}";
            }
        }
    }
}
