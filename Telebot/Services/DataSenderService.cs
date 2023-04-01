using Telebot.Commands;
using Telegram.Bot;

namespace Telebot.Services
{
    public class DataSenderService : BackgroundService
    {
        private readonly ITelegramBotClient _botClient;
        private readonly WeatherService _weatherService;
        private readonly UserStateService _userStateService;

        public DataSenderService(ITelegramBotClient botClient, WeatherService weatherService, UserStateService userStateService)
        {
            _botClient = botClient;
            _weatherService = weatherService;
            _userStateService = userStateService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await SendDataAsync(stoppingToken);

                var now = DateTime.UtcNow;
                var previousTrigger = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0, now.Kind);
                var nextTrigger = previousTrigger + TimeSpan.FromHours(1);
                await Task.Delay(nextTrigger - now, stoppingToken).ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        private async Task SendDataAsync(CancellationToken cancellationToken)
        {
            if (_userStateService.HasUsersStatesAny())
            {
                foreach (var userState in _userStateService.GetAll())
                {
                    if (userState.Subscriptions.Any())
                    {
                        foreach (var subscription in userState.Subscriptions)
                        {
                            await SendCurrentDataSubscriptionCommand.ExecuteAsync(
                                subscription, _botClient, userState, _weatherService, cancellationToken);
                        }
                    }
                }
            }
        }
    }
}
