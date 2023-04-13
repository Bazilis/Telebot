using Telegram.Bot;

namespace Telebot.Services
{
    public class AwakeService : BackgroundService
    {
        private readonly long _id;
        private readonly ITelegramBotClient _botClient;

        public AwakeService(ITelegramBotClient botClient)
        {
            _id = int.Parse(Environment.GetEnvironmentVariable("Id"));
            _botClient = botClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _botClient.SendChatActionAsync(_id, Telegram.Bot.Types.Enums.ChatAction.Typing);

                var now = DateTime.UtcNow;
                var previousTrigger = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0, now.Kind);
                var nextTrigger = previousTrigger + TimeSpan.FromMinutes(int.Parse(Environment.GetEnvironmentVariable("Delay")));
                await Task.Delay(nextTrigger - now, stoppingToken).ConfigureAwait(continueOnCapturedContext: false);
            }
        }
    }
}
