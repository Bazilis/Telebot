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
                case "a":
                    //await StartCommand.ExecuteAsync(message, botClient, userService, stateService);
                    await AirQualityInfo();
                    return;
                case "i":
                    //await StartCommand.ExecuteAsync(message, botClient, userService, stateService);
                    await CityInfo();
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

            async Task AirQualityInfo()
            {
                string airQualityTable =
                    "AQI - 1-Good, 2-Fair, 3-Moderate, 4-Poor, 5-Very Poor\n" +
                    "NO2 ----- 0-40, 40-70, 70-150, 150-200, >200\n" +
                    "SO2 ----- 0-20, 20-80, 80-250, 250-350, >350\n" +
                    "PM2.5 --- 0-10, 10-25, 25-50, 50-75, >75\n" +
                    "PM10 ---- 0-20, 20-50, 50-100, 100-200, >200\n" +
                    "O3 ------ 0-60, 60-100, 100-140, 140-180, >180\n" +
                    "CO - 0-4400, 4400-9400, 9400-12400, 12400-15400, >15400\n" +
                    "NO ------ 0-100\n" +
                    "NH3 ----- 0-200\n";
                await botClient.SendTextMessageAsync(message.Chat.Id, airQualityTable);
                await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
            }

            async Task CityInfo()
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
                else
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
