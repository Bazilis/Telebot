using Telebot.Services;
using Telegram.Bot.Types;

namespace Telebot.Commands
{
    public class SetUserTimezoneCommand
    {
        public static void Execute(CallbackQuery callback, UserStateService userStateService)
        {
            _ = userStateService.SetResetUserTimeZoneOffset(callback.From.Id, int.Parse($"{callback.Data}"));
        }
    }
}
