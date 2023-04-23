using Telebot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Telebot.Commands
{
    public class ServiceUserCommand
    {
        public static async Task ExecuteAsync(Message message, ITelegramBotClient botClient, UserStateService userStateService)
        {
            await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);

            var userStates = userStateService.GetAll().ToArray();
            if (message.From.Id == long.Parse(Environment.GetEnvironmentVariable("Id")))
            {
                string str = $"Total >>> {userStates.Length}\n\n";
                foreach (var userState in userStates)
                {
                    str += $"{userState.UserId}\n";
                    if (userState.Subscriptions.Any())
                    {
                        foreach (var subscription in userState.Subscriptions)
                            str += $"{subscription.City}\n";
                        str += "\n";
                    }
                }
                await botClient.SendTextMessageAsync(message.Chat.Id, str);
            }
        }
    }
}
