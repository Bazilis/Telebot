using Telebot.Services;
using Telegram.Bot.Types;

namespace Telebot.Commands
{
    public class SubscribeUserToCityCommand
    {
        public static void ExecuteAsync(CallbackQuery callback, UserStateService userStateService)
        {
            _ = userStateService.SubscribeUnsubscribeUser(callback.From.Id, callback.Data);
        }
    }
}
