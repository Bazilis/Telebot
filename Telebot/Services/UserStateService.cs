using Telebot.Dto;

namespace Telebot.Services
{
    public class UserStateService
    {
        private List<UserStateDto> UsersStates { get; set; } = new();

        public void AddUserState(UserStateDto state)
        {
            UsersStates.Add(state);
        }

        public bool HasUsersStatesAny()
        {
            return UsersStates.Any();
        }

        public List<UserStateDto> GetAll() => UsersStates;

        public UserStateDto GetUserStateByUserIdAsync(long userId)
        {
            return UsersStates.FirstOrDefault(x => x.UserId == userId);
        }

        public string SetResetUserTimeZoneOffset(long userId, int offset)
        {
            var userState = GetUserStateByUserIdAsync(userId);

            if (userState == default)
            {
                UsersStates.Add(new UserStateDto
                {
                    UserId = userId,
                    TimeZoneOffset = offset
                });

                return $"Welcome, time zone set to {offset}";
            }

            if (userState.TimeZoneOffset == offset)
            {
                userState.TimeZoneOffset = 0;
                return $"Time zone reset";
            }
            else
            {
                userState.TimeZoneOffset = offset;
                return $"Time zone set to {offset}";
            }
        }

        public string SubscribeUnsubscribeUser(long userId, string city)
        {
            var subscription = SubscriptionConstants.SubscriptionsList.FirstOrDefault(s => s.City == city);

            if (subscription == default) return "Сity not found";

            var userState = GetUserStateByUserIdAsync(userId);

            if (userState == default)
            {
                UsersStates.Add(new UserStateDto
                {
                    UserId = userId,
                    Subscriptions = new List<SubscriptionDto> { subscription }
                });

                return $"Welcome, you subscribed to {subscription.City}";
            }

            var userSubscription = userState.Subscriptions.FirstOrDefault(s => s.City == city);

            if (userSubscription == default)
            {
                userState.Subscriptions.Add(subscription);
                return $"You subscribed to {subscription.City}";
            }
            else
            {
                userState.Subscriptions.Remove(userSubscription);
                return $"You unsubscribed from {subscription.City}";
            }
        }
    }
}
