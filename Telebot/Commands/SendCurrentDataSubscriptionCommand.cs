using Telebot.Dto;
using Telebot.Services;
using Telegram.Bot;

namespace Telebot.Commands
{
    public class SendCurrentDataSubscriptionCommand
    {
        public static async Task ExecuteAsync(SubscriptionDto subscription, ITelegramBotClient botClient, UserStateDto userState, WeatherService weatherService)
        {
            if (userState.IsShortMode)
            {
                string weatherReport = await weatherService.GetReport(subscription, userState, true);

                if (subscription.SecondMessageId != 0)
                {
                    await botClient.DeleteMessageAsync(userState.UserId, subscription.SecondMessageId);
                    var responce = await botClient.SendTextMessageAsync(userState.UserId, weatherReport);
                    subscription.SecondMessageId = subscription.FirstMessageId;
                    subscription.FirstMessageId = responce.MessageId;
                }
                else
                {
                    var responce = await botClient.SendTextMessageAsync(userState.UserId, weatherReport);
                    subscription.SecondMessageId = subscription.FirstMessageId;
                    subscription.FirstMessageId = responce.MessageId;
                }
            }
            else
            {
                string weatherReport = await weatherService.GetReport(subscription, userState, true);
                await botClient.SendTextMessageAsync(userState.UserId, weatherReport);
            }
        }
    }
}
