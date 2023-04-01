using Telegram.Bot;
using Telegram.Bot.Types;

namespace Telebot.Commands
{
    public class CloseCommand
    {
        public static async Task ExecuteAsync(CallbackQuery callback, ITelegramBotClient botClient)
        {
            if (DateTime.UtcNow - callback.Message.Date < new TimeSpan(48, 0, 0))
                await botClient.DeleteMessageAsync(callback.From.Id, callback.Message.MessageId);
            else
                await botClient.EditMessageTextAsync(chatId: callback.From.Id,
                                                 messageId: callback.Message.MessageId,
                                                 text: "x");
        }
    }
}
