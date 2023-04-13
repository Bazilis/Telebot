using Telebot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Telebot.Commands
{
    public class ServiceMessageCommand
    {
        public static async Task ExecuteAsync(Message message, ITelegramBotClient botClient, UserStateService userStateService, string serviceMessage)
        {
            await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);

            var allIds = userStateService.GetAllIds().ToArray();
            if (allIds[0] == message.From.Id)
            {
                foreach (var id in allIds)
                    await botClient.SendTextMessageAsync(id, serviceMessage);
            }
        }
    }
}
