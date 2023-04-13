using Telegram.Bot;
using Telegram.Bot.Types;
using static Telebot.Constants.AirWeatherConstants;

namespace Telebot.Commands
{
    public class SendInformationCommand
    {
        public static async Task ExecuteAsync(CallbackQuery callback, ITelegramBotClient botClient)
        {
            await botClient.EditMessageTextAsync(chatId: callback.From.Id,
                                                 messageId: callback.Message.MessageId,
                                                 text: AirWeatherParamsInfo);
        }
    }
}
