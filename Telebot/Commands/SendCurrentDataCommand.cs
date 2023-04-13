using Telebot.Constants;
using Telebot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Telebot.Commands
{
    public class SendCurrentDataCommand
    {
        public static async Task ExecuteAsync(CallbackQuery callback, ITelegramBotClient botClient, UserStateService userStateService, WeatherService weatherService)
        {
            var citySubscription = SubscriptionConstants.SubscriptionsList.FirstOrDefault(s => s.City == callback.Data);
            var userState = userStateService.GetUserStateByUserId(callback.From.Id);

            string cityReport = await weatherService.GetReport(citySubscription, userState);

            await botClient.EditMessageTextAsync(chatId: callback.From.Id,
                                                 messageId: callback.Message.MessageId,
                                                 text: cityReport);
        }
    }
}
