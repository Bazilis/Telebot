using Telegram.Bot;

namespace Telebot.Services
{
    public class TimerService : BackgroundService
    {
        private readonly ITelegramBotClient _botClient;
        private readonly WeatherService _weatherService;
        private readonly SubscriptionService _subscriptionService;

        public TimerService(ITelegramBotClient botClient, WeatherService weatherService, SubscriptionService subscriptionService)
        {
            _botClient = botClient;
            _weatherService = weatherService;
            _subscriptionService = subscriptionService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                foreach(var subscription in _subscriptionService.Subscriptions)
                {
                    if (subscription.SubscribersList.Any())
                    {
                        var weatherReport = await _weatherService.GetReport(subscription);
                        foreach (var subscriber in subscription.SubscribersList)
                        {
                            await _botClient.SendTextMessageAsync(subscriber, $"==============>{subscription.City}", cancellationToken: stoppingToken);
                            await _botClient.SendTextMessageAsync(subscriber, weatherReport, cancellationToken: stoppingToken);
                        }
                    }
                }

                var now = DateTime.UtcNow;
                var previousTrigger = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0, now.Kind);
                var nextTrigger = previousTrigger + TimeSpan.FromHours(1);
                await Task.Delay(nextTrigger - now, stoppingToken).ConfigureAwait(continueOnCapturedContext: false);
            }
        }
    }
}
