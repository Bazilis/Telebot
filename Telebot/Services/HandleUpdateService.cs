using Telebot.Handlers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telebot.Services
{
    public class HandleUpdateService
    {
        private readonly ITelegramBotClient _botClient;
        private readonly WeatherService _weatherService;
        private readonly UserService _subscriberService;

        public HandleUpdateService(ITelegramBotClient botClient, WeatherService weatherService, UserService subscriberService)
        {
            _botClient = botClient;
            _weatherService = weatherService;
            _subscriberService = subscriberService;
        }

        public async Task Handle(Update update)
        {
            //if (update.Message != null)
            //{
            //    var user = await _userService.GetByTelegramIdAsync(update.Message.From.Id);
            //    if (user == null)
            //    {
            //        await _botClient.SendTextMessageAsync(update.Message.From.Id, "You are not authorized.");
            //        return;
            //    }
            //}

            switch (update.Type)
            {
                case UpdateType.Message:
                    await MessageHandler.HandleAsync(update.Message, _botClient, _weatherService, _subscriberService);//, _userService, _stateService);
                    return;

                //case UpdateType.CallbackQuery:
                //    await CallbackQueryHandler.HandleAsync(
                //            update.CallbackQuery,
                //            _botClient,
                //            _userService,
                //            _stateService,
                //            _historyService,
                //            _officeService,
                //            _mapService,
                //            _workPlaceService,
                //            _bookingService,
                //            _parkingPlaceService);
                //    return;
            }
        }
    }
}
