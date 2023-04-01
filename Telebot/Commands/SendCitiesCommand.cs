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
            var cities = SubscriptionConstants.SubscriptionsList.Select(x => x.City);
            var buttons = new List<InlineKeyboardButton>();
            foreach (var city in cities)
            {
                buttons.Add(InlineKeyboardButton.WithCallbackData(city, city));
            }
            var backButton = Tuple.Create(UserStateEnum.NoState, "Back");

            var inlineKeyboard = KeyboardBuilder.BuildInLineKeyboard(buttons, 2, backButton);
            await botClient.EditMessageTextAsync(chatId: callback.From.Id,
                                                 messageId: callback.Message.MessageId,
                                                 text: "Select a city ===>>>",
                                                 replyMarkup: inlineKeyboard);
        }
    }
}
