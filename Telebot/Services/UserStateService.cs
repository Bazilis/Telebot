using System.Collections.Concurrent;
using Telebot.Constants;
using Telebot.Dto;

namespace Telebot.Services
{
    public class UserStateService
    {
        private readonly ConcurrentDictionary<long, UserStateDto> _usersStates = new();

        public void AddUserState(UserStateDto state)
        {
            _usersStates.TryAdd(state.UserId, state);
        }

        public bool HasAnyUsersStates()
        {
            return !_usersStates.IsEmpty;
        }

        public ICollection<UserStateDto> GetAll()
        {
            return _usersStates.Values;
        }

        public ICollection<long> GetAllIds()
        {
            return _usersStates.Keys;
        }

        public UserStateDto GetUserStateByUserId(long userId)
        {
            _usersStates.TryGetValue(userId, out var userState);
            return userState;
        }

        public string SetResetShortMode(long userId)
        {
            _usersStates.TryGetValue(userId, out var userState);

            if (userState == null)
            {
                userState = new UserStateDto
                {
                    UserId = userId,
                    IsShortMode = true
                };
                _usersStates.TryAdd(userId, userState);

                return $"Welcome, short mode on";
            }

            if (userState.IsShortMode)
            {
                userState.IsShortMode = false;
                userState.Subscriptions.ForEach(x => { x.FirstMessageId = 0; x.SecondMessageId = 0; });
                return $"Short mode off";
            }
            else
            {
                userState.IsShortMode = true;
                return $"Short mode on";
            }
        }

        public string SetResetUserTimeZoneOffset(long userId, int offset)
        {
            _usersStates.TryGetValue(userId, out var userState);

            if (userState == null)
            {
                userState = new UserStateDto
                {
                    UserId = userId,
                    TimeZoneOffset = offset
                };
                _usersStates.TryAdd(userId, userState);
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

            if (subscription == null) return "City not found";

            _usersStates.TryGetValue(userId, out var userState);

            if (userState == null)
            {
                userState = new UserStateDto
                {
                    UserId = userId,
                    Subscriptions = new List<SubscriptionDto> { subscription }
                };
                _usersStates.TryAdd(userId, userState);
                return $"Welcome, you subscribed to {subscription.City}";
            }

            var userSubscription = userState.Subscriptions.FirstOrDefault(s => s.City == city);

            if (userSubscription == null)
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
