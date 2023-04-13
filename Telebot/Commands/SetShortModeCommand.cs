using Telebot.Services;
using Telegram.Bot.Types;

namespace Telebot.Commands
{
    public class SetShortModeCommand
    {
        public static void Execute(CallbackQuery callback, UserStateService userStateService)
        {
            _ = userStateService.SetResetShortMode(callback.From.Id);
        }
    }
}
