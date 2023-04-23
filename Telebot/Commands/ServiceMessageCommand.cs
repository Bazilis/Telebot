using Telebot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Telebot.Commands
{
    public class ServiceMessageCommand
    {
        public static async Task ExecuteAsync(Message message, ITelegramBotClient botClient, UserStateService userStateService, string[] serviceParams)
        {
            await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);

            var allIds = userStateService.GetAllIds().ToArray();
            if (allIds[^1] == message.From.Id)
            {
                var id = allIds.FirstOrDefault(x => x == long.Parse(serviceParams[0]));

                if (id != 0)
                {
                    await botClient.SendTextMessageAsync(id, serviceParams[1]);
                    await botClient.SendTextMessageAsync(message.Chat.Id, "OK");
                }
                else
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "NOT OK");
                }
            }
        }
    }
}
