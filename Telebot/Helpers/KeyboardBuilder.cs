using Telebot.Dto;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telebot.Helpers
{
    public class KeyboardBuilder
    {
        public static InlineKeyboardMarkup BuildInLineKeyboard(InlineKeyboardButton[] buttons, int totalColumns, Tuple<UserStateEnum, string>? backButton = null)
        {
            InlineKeyboardButton[][] buttonRows;
            int buttonRowsCount;
            int remainder = buttons.Length % totalColumns;

            if (remainder == 0)
            {
                buttonRowsCount = buttons.Length / totalColumns;
                // additional row for "back" and "close" buttons
                buttonRows = new InlineKeyboardButton[buttonRowsCount + 1][];

                for (int i = 0; i < buttonRowsCount; i++)
                {
                    buttonRows[i] = new InlineKeyboardButton[totalColumns];
                    for (int j = 0; j < totalColumns; j++)
                    {
                        buttonRows[i][j] = buttons[i * totalColumns + j];
                    }
                }
            }
            else
            {
                // additional row for remainder
                buttonRowsCount = (buttons.Length / totalColumns) + 1;
                // additional row for "back" and "close" buttons
                buttonRows = new InlineKeyboardButton[buttonRowsCount + 1][];

                for (int i = 0; i < buttonRowsCount - 1; i++)
                {
                    buttonRows[i] = new InlineKeyboardButton[totalColumns];
                    for (int j = 0; j < totalColumns; j++)
                    {
                        buttonRows[i][j] = buttons[i * totalColumns + j];
                    }
                }

                buttonRows[buttonRowsCount - 1] = new InlineKeyboardButton[remainder];
                for (int j = 0; j < remainder; j++)
                {
                    buttonRows[buttonRowsCount - 1][j] = buttons[buttons.Length - remainder + j];
                }
            }

            if (backButton != null)
            {
                buttonRows[buttonRowsCount] = new InlineKeyboardButton[]
                {
                    InlineKeyboardButton.WithCallbackData("⬅ back", $"data:{backButton.Item1}:{backButton.Item2}"),
                    InlineKeyboardButton.WithCallbackData("close ❌", $"data:{UserStateEnum.NoState}:Close")
                };
            }
            else
            {
                buttonRows[buttonRowsCount] = new InlineKeyboardButton[]
                {
                    InlineKeyboardButton.WithCallbackData("close ❌", $"data:{UserStateEnum.NoState}:Close")
                };
            }

            return buttonRows;
        }
    }
}
