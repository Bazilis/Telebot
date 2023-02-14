using Telebot.Srevices;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Telebot.Handlers
{
    public class MessageHandler
    {
        public static async Task HandleAsync(Message message, ITelegramBotClient botClient, WeatherService weatherService)//, IAppUserService userService, IStateService stateService)
        {
            switch (message.Text)
            {
                case "/start":
                    //await StartCommand.ExecuteAsync(message, botClient, userService, stateService);
                    await botClient.SendTextMessageAsync(message.Chat.Id, "=====================");
                    var weatherReport = await weatherService.GetReport();
                    await botClient.SendTextMessageAsync(message.Chat.Id, weatherReport);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                default:
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
            }
        }
    }
}
