using Telebot.Dto;
using Telebot.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telebot.Commands
{
    public class SendTimezonesCommand
    {
        public static async Task ExecuteAsync(CallbackQuery callback, ITelegramBotClient botClient, UserStateDto userState)
        {
            var buttons = new List<InlineKeyboardButton>();

            for (int i = 0; i < 6; i++)
            {
                if (userState.TimeZoneOffset == i)
                    buttons.Add(InlineKeyboardButton.WithCallbackData($"GMT+{i} ✅", $"{i}"));
                else
                    buttons.Add(InlineKeyboardButton.WithCallbackData($"GMT+{i}", $"{i}"));
            }

            var backButton = Tuple.Create(UserStateEnum.NoState, "Back");

            var inlineKeyboard = KeyboardBuilder.BuildInLineKeyboard(buttons, 2, backButton);
            await botClient.EditMessageTextAsync(chatId: callback.From.Id,
                                                 messageId: callback.Message.MessageId,
                                                 text: "Select a time zone ===>>>",
                                                 replyMarkup: inlineKeyboard);
        }
    }
}
