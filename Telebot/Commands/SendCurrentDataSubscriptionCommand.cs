using Telebot.Dto;
using Telebot.Services;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace Telebot.Commands
{
    public class SendCurrentDataSubscriptionCommand
    {
        public static async Task ExecuteAsync(SubscriptionDto subscription, ITelegramBotClient botClient, UserStateDto userState, WeatherService weatherService, CancellationToken stoppingToken)
        {
            await botClient.SendChatActionAsync(userState.UserId, ChatAction.Typing, cancellationToken: stoppingToken);
            string weatherReport = await weatherService.GetReport(subscription, userState, true);
            await botClient.SendTextMessageAsync(userState.UserId, weatherReport, cancellationToken: stoppingToken);
        }
    }
}
