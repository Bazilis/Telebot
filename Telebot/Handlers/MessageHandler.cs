using Telebot.Commands;
using Telebot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using static Telebot.Constants.AirWeatherConstants;

namespace Telebot.Handlers
{
    public class MessageHandler
    {
        public static async Task HandleAsync(Message message, ITelegramBotClient botClient, UserStateService userStateService)
        {
            var serviceMessage = "No message";

            if (message.Text.Length > 5 && message.Text.Substring(0, 5).Equals("mess:"))
            {
                var data = message.Text.Split(":");
                message.Text = data[0];
                serviceMessage = data[1];
            }

            switch (message.Text)
            {
                case "/menu_buttons" or "/start":
                    await StartCommand.ExecuteAsync(message, botClient, userStateService);
                    return;
                case "c":
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    await botClient.SendTextMessageAsync(message.Chat.Id, AvailableCities);
                    return;
                case "mess":
                    await ServiceMessageCommand.ExecuteAsync(message, botClient, userStateService, serviceMessage);
                    return;
                case "us":
                    await ServiceUserCommand.ExecuteAsync(message, botClient, userStateService);
                    return;
                default:
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
            }
        }
    }
}
