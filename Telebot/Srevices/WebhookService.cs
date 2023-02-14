using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace Telebot.Srevices
{
    public class WebhookService : IHostedService
    {
        private readonly IConfiguration _configuration;
        private readonly ITelegramBotClient _botClient;

        public WebhookService(IConfiguration configuration, ITelegramBotClient botClient)
        {
            _configuration = configuration;
            _botClient = botClient;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            //var webhookAddress = $@"{_configuration["BotHostAddress"]}/api/TelegramBot";
            var webhookAddress = $@"{Environment.GetEnvironmentVariable("BotHostAddress")}/api/TelegramBot";
            await _botClient.SetWebhookAsync(
                url: webhookAddress,
                allowedUpdates: Array.Empty<UpdateType>(),
                dropPendingUpdates: true,
                cancellationToken: cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _botClient.DeleteWebhookAsync(dropPendingUpdates: true, cancellationToken: cancellationToken);
        }
    }
}
