using Telebot.Dto;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telebot.Helpers
{
    public class KeyboardBuilder
    {
        public static InlineKeyboardMarkup BuildInLineKeyboard(List<InlineKeyboardButton> buttons, int totalColumns, Tuple<UserStateEnum, string>? backButton = null)
        {
            int rowLength = 0;
            var row = new List<InlineKeyboardButton>();
            var rows = new List<List<InlineKeyboardButton>>();

            foreach (var button in buttons)
            {
                row.Add(button);
                rowLength++;

                if (rowLength >= totalColumns)
                {
                    rows.Add(row);
                    rowLength = 0;
                    row = new List<InlineKeyboardButton>();
                }
            }
            if (rowLength > 0)
                rows.Add(row);


            if (backButton != null)
            {
                rows.Add(new List<InlineKeyboardButton>
                {
                    InlineKeyboardButton.WithCallbackData("<<<=== back", $"data:{backButton.Item1}:{backButton.Item2}"),
                    InlineKeyboardButton.WithCallbackData("close [X]", $"data:{UserStateEnum.NoState}:Close")
                });
            }
            else
            {
                rows.Add(new List<InlineKeyboardButton>
                {
                    InlineKeyboardButton.WithCallbackData("close [X]", $"data:{UserStateEnum.NoState}:Close")
                });
            }

            return new InlineKeyboardMarkup(rows);
        }
    }
}
