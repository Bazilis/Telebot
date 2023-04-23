using Telebot.Dto;
using Telebot.Constants;
using Telebot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Telebot.Commands
{
    public class SubscribeUserCommand
    {
        public static async Task ExecuteAsync(Message message, ITelegramBotClient botClient, UserStateService userStateService, string[] serviceParams)
        {
            await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);

            var userStates = userStateService.GetAll().ToArray();
            if (userStates[0].UserId == message.From.Id)
            {
                var userState = userStates.FirstOrDefault(x => x.UserId == long.Parse(serviceParams[0]));

                if (userState == null)
                    userState = new UserStateDto { UserId = long.Parse(serviceParams[0]) };

                for (int counter = 1; counter < serviceParams.Length; counter++)
                {
                    var subscription = SubscriptionConstants.SubscriptionsList.FirstOrDefault(x => x.City == serviceParams[counter]);

                    if (subscription != null)
                        userState.Subscriptions.Add(subscription);
                }

                userStateService.AddUserState(userState);

                await botClient.SendTextMessageAsync(message.Chat.Id, "OK");
            }
        }
    }
}
