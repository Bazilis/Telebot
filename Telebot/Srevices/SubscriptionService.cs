using Telebot.Dto;

namespace Telebot.Srevices
{
    public class SubscriptionService
    {
        public List<SubscriptionDto> Subscriptions { get; set; }

        public SubscriptionService()
        {
            Subscriptions = SubscriptionConstants.SubscriptionsList;
        }

        public string SubscribeUnsubscribe(string city, long userId)
        {
            var subscription = Subscriptions.FirstOrDefault(s => s.City == city);

            if(subscription != default)
            {
                if(subscription.SubscribersList.Any(s => s == userId))
                {
                    subscription.SubscribersList.Remove(userId);
                    return $"Unsubscribe from {subscription.City}";
                }
                else
                {
                    subscription.SubscribersList.Add(userId);
                    return $"Subscribe to {subscription.City}";
                }
            }

            return "Сity not found";
        }
    }
}
