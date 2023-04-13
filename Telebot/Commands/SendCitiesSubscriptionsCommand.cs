using Telebot.Constants;
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
            var allCities = SubscriptionConstants.SubscriptionsList.Select(x => x.City).ToArray();

            var userState = userStateService.GetUserStateByUserId(callback.From.Id);

            var userSubscribeCities = userState.Subscriptions.Select(x => x.City);

            var buttons = new InlineKeyboardButton[allCities.Length + 1];

            for(int i = 0; i < allCities.Length; i++)
            {
                buttons[i] = userSubscribeCities.Any(x => x == allCities[i])
                    ? InlineKeyboardButton.WithCallbackData($"{allCities[i]} ✅", allCities[i])
                    : InlineKeyboardButton.WithCallbackData($"{allCities[i]}", allCities[i]);
            }

            buttons[^1] = userState.IsShortMode
                ? InlineKeyboardButton.WithCallbackData("SHORT MODE ✅", "Short mode")
                : InlineKeyboardButton.WithCallbackData("SHORT MODE", "Short mode");

            var backButton = Tuple.Create(UserStateEnum.NoState, "Back");

            var inlineKeyboard = KeyboardBuilder.BuildInLineKeyboard(buttons, 2, backButton);
            await botClient.EditMessageTextAsync(chatId: callback.From.Id,
                                                 messageId: callback.Message.MessageId,
                                                 text: "Select a city to subscribe:",
                                                 replyMarkup: inlineKeyboard);
        }
    }
}
