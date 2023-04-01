using Telebot.Dto;
using Telebot.Helpers;
using Telebot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telebot.Commands
{
    public class StartCommand
    {
        static readonly List<InlineKeyboardButton> buttons = new()
        {
            InlineKeyboardButton.WithCallbackData("Get Current Data", "Get Current Data"),
            InlineKeyboardButton.WithCallbackData("Subscriptions", "Subscriptions"),
            InlineKeyboardButton.WithCallbackData("Air Quality Info", "Air Quality Info"),
            InlineKeyboardButton.WithCallbackData("Select timezone", "Select timezone")
        };

        public static async Task ExecuteAsync(Message message, ITelegramBotClient botClient, UserStateService userStateService)
        {
            await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);

            var userState = userStateService.GetUserStateByUserIdAsync(message.From.Id);

            if (userState == null)
            {
                userState = new UserStateDto { UserId = message.From.Id };
                userStateService.AddUserState(userState);
            }

            var inlineKeyboard = KeyboardBuilder.BuildInLineKeyboard(buttons, 2);
            var responce = await botClient.SendTextMessageAsync(chatId: message.From.Id,
                                                 text: "Select action ===>>>",
                                                 replyMarkup: inlineKeyboard);

            userState.LastCommand = "/start";
            userState.MessageId = responce.MessageId;
            userState.UserState = UserStateEnum.SelectingAction;
        }

        public static async Task ExecuteAsync(CallbackQuery callback, ITelegramBotClient botClient, UserStateDto userState)
        {
            var inlineKeyboard = KeyboardBuilder.BuildInLineKeyboard(buttons, 2);

            if (callback.Message.Text == "Select action ===>>>")
            {
                await botClient.AnswerCallbackQueryAsync(callback.Id, "OK");

                userState.MessageId = callback.Message.MessageId;
            }
            else
            {
                var responce = await botClient.EditMessageTextAsync(chatId: callback.From.Id,
                                             messageId: callback.Message.MessageId,
                                             text: "Select action ===>>>",
                                             replyMarkup: inlineKeyboard);

                userState.MessageId = responce.MessageId;
            }
        }
    }
}
