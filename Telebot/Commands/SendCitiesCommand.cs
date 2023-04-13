using Telebot.Constants;
using Telebot.Dto;
using Telebot.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telebot.Commands
{
    public class SendCitiesCommand
    {
        public static async Task ExecuteAsync(CallbackQuery callback, ITelegramBotClient botClient)
        {
            var cities = SubscriptionConstants.SubscriptionsList.Select(x => x.City).ToArray();

            var buttons = new InlineKeyboardButton[cities.Length];

            for (int i = 0; i < cities.Length; i++)
            {
                buttons[i] = InlineKeyboardButton.WithCallbackData(cities[i], cities[i]);
            }

            var backButton = Tuple.Create(UserStateEnum.NoState, "Back");

            var inlineKeyboard = KeyboardBuilder.BuildInLineKeyboard(buttons, 2, backButton);
            await botClient.EditMessageTextAsync(chatId: callback.From.Id,
                                                 messageId: callback.Message.MessageId,
                                                 text: "Select a city to get current data:",
                                                 replyMarkup: inlineKeyboard);
        }
    }
}
