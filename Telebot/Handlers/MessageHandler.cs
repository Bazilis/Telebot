using Telebot.Commands;
using Telebot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Telebot.Handlers
{
    public class MessageHandler
    {
        public static async Task HandleAsync(Message message, ITelegramBotClient botClient, UserStateService userStateService)
        {
            switch (message.Text)
            {
                case "/menu_buttons" or "/start":
                    await StartCommand.ExecuteAsync(message, botClient, userStateService);
                    return;
                case "i":
                    await CityInfo();
                    return;
                default:
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
            }

            async Task CityInfo()
            {
                string availableCities =
                    "Berlin\nGomel\nHurghada\nIstanbul\nJizzakh\nKaliningrad\nKyiv\nLondon\nMadrid\nMilan\nMinsk\n" +
                    "Nicosia\nNizhny Novgorod\nOdesa\nParis\nRome\nSharm el Sheikh\nTashkent\nTbilisi\nVilnius\nWarsaw\nWroclaw\n";
                await botClient.SendTextMessageAsync(message.Chat.Id, availableCities);
                await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
            }
        }
    }
}
