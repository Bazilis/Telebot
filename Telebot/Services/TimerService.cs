using Telegram.Bot;

namespace Telebot.Services
{
    public class TimerService : BackgroundService
    {
        private readonly ITelegramBotClient _botClient;
        private readonly WeatherService _weatherService;
        private readonly UserService _subscriptionService;

        public TimerService(ITelegramBotClient botClient, WeatherService weatherService, UserService subscriptionService)
        {
            _botClient = botClient;
            _weatherService = weatherService;
            _subscriptionService = subscriptionService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_subscriptionService.Users.Any())
                {
                    foreach (var user in _subscriptionService.Users)
                    {
                        if (user.Subscriptions.Any())
                        {
                            foreach(var subscription in user.Subscriptions)
                            {
                                string weatherReport;
                                if (user.TimeZoneOffset == 0)
                                {
                                    weatherReport = await _weatherService.GetReport(subscription, subscription.TimeZoneOffset);
                                }
                                else
                                {
                                    weatherReport = await _weatherService.GetReport(subscription, user.TimeZoneOffset);
                                }

                                await _botClient.SendTextMessageAsync(user.UserId, weatherReport, cancellationToken: stoppingToken);
                            }
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
