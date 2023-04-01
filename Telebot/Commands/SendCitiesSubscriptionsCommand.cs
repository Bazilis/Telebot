using Telebot.Dto;
using Telebot.Helpers;
using Telebot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telebot.Commands
{
    public class SendCitiesSubscriptionsCommand
    {
        public static async Task ExecuteAsync(CallbackQuery callback, ITelegramBotClient botClient, UserStateService userStateService)
        {
            var allCities = SubscriptionConstants.SubscriptionsList.Select(x => x.City);
            var userSubscribeCities = userStateService.GetUserStateByUserIdAsync(callback.From.Id).Subscriptions.Select(x => x.City);

            var buttons = new List<InlineKeyboardButton>();
            foreach (var city in allCities)
            {
                if(userSubscribeCities.Any(x => x == city))
                    buttons.Add(InlineKeyboardButton.WithCallbackData($"{city} ✅", city));
                else
                    buttons.Add(InlineKeyboardButton.WithCallbackData($"{city}", city));
            }

            var backButton = Tuple.Create(UserStateEnum.NoState, "Back");

            var inlineKeyboard = KeyboardBuilder.BuildInLineKeyboard(buttons, 2, backButton);
            await botClient.EditMessageTextAsync(chatId: callback.From.Id,
                                                 messageId: callback.Message.MessageId,
                                                 text: "Select a city to subscribe ===>>>",
                                                 replyMarkup: inlineKeyboard);
        }
    }
}
