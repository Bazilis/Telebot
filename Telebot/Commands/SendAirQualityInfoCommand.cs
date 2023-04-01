using Telegram.Bot;
using Telegram.Bot.Types;

namespace Telebot.Commands
{
    public class SendAirQualityInfoCommand
    {
        public static async Task ExecuteAsync(CallbackQuery callback, ITelegramBotClient botClient)
        {
            await botClient.SendChatActionAsync(callback.From.Id, Telegram.Bot.Types.Enums.ChatAction.Typing);

            string airQualityInfo =
                    "AQI ----- 1-Good, 2-Fair, 3-Moderate\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t" +
                    "4-Poor, 5-Very Poor\n" +
                    "NO2 ---- 0-40, 40-70, 70-150, 150-200, >200\n" +
                    "SO2 ----- 0-20, 20-80, 80-250, 250-350, >350\n" +
                    "PM2.5 - 0-10, 10-25, 25-50, 50-75, >75\n" +
                    "PM10 -- 0-20, 20-50, 50-100, 100-200, >200\n" +
                    "NO ------- 0-100\n" +
                    "NH3 ---- 0-200\n" +
                    "O3 --- 0-60, 60-100, 100-140, 140-180, >180\n" +
                    "CO -- 0-4400, 4400-9400, 9400-12400, 12400-15400, >15400\n";

            await botClient.EditMessageTextAsync(chatId: callback.From.Id,
                                                 messageId: callback.Message.MessageId,
                                                 text: airQualityInfo);
        }
    }
}
