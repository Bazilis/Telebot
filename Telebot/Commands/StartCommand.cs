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
        static readonly InlineKeyboardButton[] buttons = new InlineKeyboardButton[]
        {
            InlineKeyboardButton.WithCallbackData("Current data", "Current data"),
            InlineKeyboardButton.WithCallbackData("Subscriptions", "Subscriptions"),
            InlineKeyboardButton.WithCallbackData("Time zone", "Time zone"),
            InlineKeyboardButton.WithCallbackData("Information", "Information")
        };

        public static async Task ExecuteAsync(Message message, ITelegramBotClient botClient, UserStateService userStateService)
        {
            await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);

            var userState = userStateService.GetUserStateByUserId(message.From.Id);

            if (userState == null)
            {
                userState = new UserStateDto { UserId = message.From.Id };
                userStateService.AddUserState(userState);
            }

            var inlineKeyboard = KeyboardBuilder.BuildInLineKeyboard(buttons, 3);
            var responce = await botClient.SendTextMessageAsync(chatId: message.From.Id,
                                                 text: "Select an action:",
                                                 replyMarkup: inlineKeyboard);

            userState.LastCommand = "/start";
            userState.UserState = UserStateEnum.SelectingAction;
        }

        public static async Task ExecuteAsync(CallbackQuery callback, ITelegramBotClient botClient, UserStateDto userState)
        {
            var inlineKeyboard = KeyboardBuilder.BuildInLineKeyboard(buttons, 3);

            if (callback.Message.Text == "Select an action:")
            {
                await botClient.AnswerCallbackQueryAsync(callback.Id, "OK");
            }
            else
            {
                var responce = await botClient.EditMessageTextAsync(chatId: callback.From.Id,
                                             messageId: callback.Message.MessageId,
                                             text: "Select an action:",
                                             replyMarkup: inlineKeyboard);
            }
        }
    }
}
