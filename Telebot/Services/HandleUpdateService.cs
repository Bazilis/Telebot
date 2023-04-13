using Telebot.Handlers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telebot.Services
{
    public class HandleUpdateService
    {
        private readonly ILogger<HandleUpdateService> _logger;
        private readonly ITelegramBotClient _botClient;
        private readonly UserStateService _userStateService;
        private readonly WeatherService _weatherService;

        public HandleUpdateService(ILogger<HandleUpdateService> logger, ITelegramBotClient botClient, UserStateService userStateService, WeatherService weatherService)
        {
            _logger = logger;
            _botClient = botClient;
            _userStateService = userStateService;
            _weatherService = weatherService;
        }

        public async Task Handle(Update update)
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                    await MessageHandler.HandleAsync(update.Message, _botClient, _userStateService);
                    _logger.LogInformation("MESSAGE >>> {MessageText}", update.Message.Text);
                    return;

                case UpdateType.CallbackQuery:
                    await CallbackQueryHandler.HandleAsync(update.CallbackQuery, _botClient, _userStateService, _weatherService);
                    _logger.LogInformation("CALLBACK >>> {CallbackData}", update.CallbackQuery.Data);
                    return;
            }
        }
    }
}
