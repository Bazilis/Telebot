using Telebot.Dto;
using Telebot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Telebot.Handlers
{
    public class MessageHandler
    {
        public static async Task HandleAsync(Message message, ITelegramBotClient botClient, WeatherService weatherService, UserService subscriberService)//, IAppUserService userService, IStateService stateService)
        {
            switch (message.Text)
            {
                case "i":
                    //await StartCommand.ExecuteAsync(message, botClient, userService, stateService);
                    await Info();
                    return;
                case "be":
                    await GetCityReport("Berlin");
                    return;
                case "bes":
                    await SubscribeUnsubscribeСurrentUser("Berlin");
                    return;
                case "go":
                    await GetCityReport("Gomel");
                    return;
                case "gos":
                    await SubscribeUnsubscribeСurrentUser("Gomel");
                    return;
                case "ji":
                    await GetCityReport("Jizzakh");
                    return;
                case "jis":
                    await SubscribeUnsubscribeСurrentUser("Jizzakh");
                    return;
                case "ky":
                    await GetCityReport("Kyiv");
                    return;
                case "kys":
                    await SubscribeUnsubscribeСurrentUser("Kyiv");
                    return;
                case "lo":
                    await GetCityReport("London");
                    return;
                case "los":
                    await SubscribeUnsubscribeСurrentUser("London");
                    return;
                case "ma":
                    await GetCityReport("Madrid");
                    return;
                case "mas":
                    await SubscribeUnsubscribeСurrentUser("Madrid");
                    return;
                case "mi":
                    await GetCityReport("Minsk");
                    return;
                case "mis":
                    await SubscribeUnsubscribeСurrentUser("Minsk");
                    return;
                case "ni":
                    await GetCityReport("Nizhny Novgorod");
                    return;
                case "nis":
                    await SubscribeUnsubscribeСurrentUser("Nizhny Novgorod");
                    return;
                case "od":
                    await GetCityReport("Odesa");
                    return;
                case "ods":
                    await SubscribeUnsubscribeСurrentUser("Odesa");
                    return;
                case "pa":
                    await GetCityReport("Paris");
                    return;
                case "pas":
                    await SubscribeUnsubscribeСurrentUser("Paris");
                    return;
                case "ro":
                    await GetCityReport("Rome");
                    return;
                case "ros":
                    await SubscribeUnsubscribeСurrentUser("Rome");
                    return;
                case "ta":
                    await GetCityReport("Tashkent");
                    return;
                case "tas":
                    await SubscribeUnsubscribeСurrentUser("Tashkent");
                    return;
                case "vi":
                    await GetCityReport("Vilnius");
                    return;
                case "vis":
                    await SubscribeUnsubscribeСurrentUser("Vilnius");
                    return;
                case "wa":
                    await GetCityReport("Warsaw");
                    return;
                case "was":
                    await SubscribeUnsubscribeСurrentUser("Warsaw");
                    return;
                case "wr":
                    await GetCityReport("Wroclaw");
                    return;
                case "wrs":
                    await SubscribeUnsubscribeСurrentUser("Wroclaw");
                    return;
                case "t0":
                    await SetResetСurrentUserTimeZoneOffset(0);
                    return;
                case "t1":
                    await SetResetСurrentUserTimeZoneOffset(1);
                    return;
                case "t2":
                    await SetResetСurrentUserTimeZoneOffset(2);
                    return;
                case "t3":
                    await SetResetСurrentUserTimeZoneOffset(3);
                    return;
                case "t4":
                    await SetResetСurrentUserTimeZoneOffset(4);
                    return;
                case "t5":
                    await SetResetСurrentUserTimeZoneOffset(5);
                    return;
                default:
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
            }

            async Task Info()
            {
                string availableCities = "Berlin\nGomel\nJizzakh\nKyiv\nLondon\nMadrid\nMinsk\nNizhny Novgorod\nOdesa\nParis\nRome\nTashkent\nVilnius\nWarsaw\nWroclaw\n";
                await botClient.SendTextMessageAsync(message.Chat.Id, availableCities);
                await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
            }

            async Task GetCityReport(string city)
            {
                var citySubscription = SubscriptionConstants.SubscriptionsList.FirstOrDefault(s => s.City == city);
                var user = subscriberService.Users.FirstOrDefault(u => u.UserId == message.From.Id);
                string cityReport;

                if (user == default || user.TimeZoneOffset == 0)
                    cityReport = await weatherService.GetReport(citySubscription, citySubscription.TimeZoneOffset);

                cityReport = await weatherService.GetReport(citySubscription, user.TimeZoneOffset);
                await botClient.SendTextMessageAsync(message.Chat.Id, cityReport);
                await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
            }

            async Task SubscribeUnsubscribeСurrentUser(string city)
            {
                string result = subscriberService.SubscribeUnsubscribeUser(message.From.Id, city);
                await botClient.SendTextMessageAsync(message.Chat.Id, result);
                await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
            }

            async Task SetResetСurrentUserTimeZoneOffset(int timeZoneOffset)
            {
                string result = subscriberService.SetResetUserTimeZoneOffset(message.From.Id, timeZoneOffset);
                await botClient.SendTextMessageAsync(message.Chat.Id, result);
                await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
            }
        }
    }
}
