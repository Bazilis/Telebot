using Telebot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Telebot.Handlers
{
    public class MessageHandler
    {
        public static async Task HandleAsync(Message message, ITelegramBotClient botClient, WeatherService weatherService, SubscriptionService subscriberService)//, IAppUserService userService, IStateService stateService)
        {
            switch (message.Text)
            {
                case "h":
                    string availableCities = "Berlin\nGomel\nJizzakh\nKyiv\nLondon\nMadrid\nMinsk\nOdesa\nParis\nRome\nTashkent\nVilnius\nWarsaw\nWroclaw\n";
                    await botClient.SendTextMessageAsync(message.Chat.Id, availableCities);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "be":
                    //await StartCommand.ExecuteAsync(message, botClient, userService, stateService);
                    await botClient.SendTextMessageAsync(message.Chat.Id, "==============>Berlin");
                    var berlinReport = await weatherService.GetReport(subscriberService.Subscriptions.FirstOrDefault(s => s.City == "Berlin"));
                    await botClient.SendTextMessageAsync(message.Chat.Id, berlinReport);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "bes":
                    string berlinResult = subscriberService.SubscribeUnsubscribe("Berlin", message.From.Id);
                    await botClient.SendTextMessageAsync(message.Chat.Id, berlinResult);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "go":
                    await botClient.SendTextMessageAsync(message.Chat.Id, "==============>Gomel");
                    var gomelReport = await weatherService.GetReport(subscriberService.Subscriptions.FirstOrDefault(s => s.City == "Gomel"));
                    await botClient.SendTextMessageAsync(message.Chat.Id, gomelReport);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "gos":
                    string gomelResult = subscriberService.SubscribeUnsubscribe("Gomel", message.From.Id);
                    await botClient.SendTextMessageAsync(message.Chat.Id, gomelResult);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "ji":
                    await botClient.SendTextMessageAsync(message.Chat.Id, "==============>Jizzakh");
                    var jizzakhReport = await weatherService.GetReport(subscriberService.Subscriptions.FirstOrDefault(s => s.City == "Jizzakh"));
                    await botClient.SendTextMessageAsync(message.Chat.Id, jizzakhReport);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "jis":
                    string jizzakhResult = subscriberService.SubscribeUnsubscribe("Jizzakh", message.From.Id);
                    await botClient.SendTextMessageAsync(message.Chat.Id, jizzakhResult);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "ky":
                    await botClient.SendTextMessageAsync(message.Chat.Id, "==============>Kyiv");
                    var kyivReport = await weatherService.GetReport(subscriberService.Subscriptions.FirstOrDefault(s => s.City == "Kyiv"));
                    await botClient.SendTextMessageAsync(message.Chat.Id, kyivReport);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "kys":
                    string kyivResult = subscriberService.SubscribeUnsubscribe("Kyiv", message.From.Id);
                    await botClient.SendTextMessageAsync(message.Chat.Id, kyivResult);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "lo":
                    await botClient.SendTextMessageAsync(message.Chat.Id, "==============>London");
                    var londonReport = await weatherService.GetReport(subscriberService.Subscriptions.FirstOrDefault(s => s.City == "London"));
                    await botClient.SendTextMessageAsync(message.Chat.Id, londonReport);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "los":
                    string londonResult = subscriberService.SubscribeUnsubscribe("London", message.From.Id);
                    await botClient.SendTextMessageAsync(message.Chat.Id, londonResult);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "ma":
                    await botClient.SendTextMessageAsync(message.Chat.Id, "==============>Madrid");
                    var madridReport = await weatherService.GetReport(subscriberService.Subscriptions.FirstOrDefault(s => s.City == "Madrid"));
                    await botClient.SendTextMessageAsync(message.Chat.Id, madridReport);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "mas":
                    string madridResult = subscriberService.SubscribeUnsubscribe("Madrid", message.From.Id);
                    await botClient.SendTextMessageAsync(message.Chat.Id, madridResult);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "mi":
                    await botClient.SendTextMessageAsync(message.Chat.Id, "==============>Minsk");
                    var minskReport = await weatherService.GetReport(subscriberService.Subscriptions.FirstOrDefault(s => s.City == "Minsk"));
                    await botClient.SendTextMessageAsync(message.Chat.Id, minskReport);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "mis":
                    string minskResult = subscriberService.SubscribeUnsubscribe("Minsk", message.From.Id);
                    await botClient.SendTextMessageAsync(message.Chat.Id, minskResult);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "od":
                    await botClient.SendTextMessageAsync(message.Chat.Id, "==============>Odesa");
                    var odesaReport = await weatherService.GetReport(subscriberService.Subscriptions.FirstOrDefault(s => s.City == "Odesa"));
                    await botClient.SendTextMessageAsync(message.Chat.Id, odesaReport);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "ods":
                    string odesaResult = subscriberService.SubscribeUnsubscribe("Odesa", message.From.Id);
                    await botClient.SendTextMessageAsync(message.Chat.Id, odesaResult);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "pa":
                    await botClient.SendTextMessageAsync(message.Chat.Id, "==============>Paris");
                    var parisReport = await weatherService.GetReport(subscriberService.Subscriptions.FirstOrDefault(s => s.City == "Paris"));
                    await botClient.SendTextMessageAsync(message.Chat.Id, parisReport);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "pas":
                    string parisResult = subscriberService.SubscribeUnsubscribe("Paris", message.From.Id);
                    await botClient.SendTextMessageAsync(message.Chat.Id, parisResult);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "ro":
                    await botClient.SendTextMessageAsync(message.Chat.Id, "==============>Rome");
                    var romeReport = await weatherService.GetReport(subscriberService.Subscriptions.FirstOrDefault(s => s.City == "Rome"));
                    await botClient.SendTextMessageAsync(message.Chat.Id, romeReport);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "ros":
                    string romeResult = subscriberService.SubscribeUnsubscribe("Rome", message.From.Id);
                    await botClient.SendTextMessageAsync(message.Chat.Id, romeResult);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "ta":
                    await botClient.SendTextMessageAsync(message.Chat.Id, "============>Tashkent");
                    var tashkentReport = await weatherService.GetReport(subscriberService.Subscriptions.FirstOrDefault(s => s.City == "Tashkent"));
                    await botClient.SendTextMessageAsync(message.Chat.Id, tashkentReport);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "tas":
                    string tashkentResult = subscriberService.SubscribeUnsubscribe("Tashkent", message.From.Id);
                    await botClient.SendTextMessageAsync(message.Chat.Id, tashkentResult);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "vi":
                    await botClient.SendTextMessageAsync(message.Chat.Id, "==============>Vilnius");
                    var vilniusReport = await weatherService.GetReport(subscriberService.Subscriptions.FirstOrDefault(s => s.City == "Vilnius"));
                    await botClient.SendTextMessageAsync(message.Chat.Id, vilniusReport);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "vis":
                    string vilniusResult = subscriberService.SubscribeUnsubscribe("Vilnius", message.From.Id);
                    await botClient.SendTextMessageAsync(message.Chat.Id, vilniusResult);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "wa":
                    await botClient.SendTextMessageAsync(message.Chat.Id, "==============>Warsaw");
                    var warsawReport = await weatherService.GetReport(subscriberService.Subscriptions.FirstOrDefault(s => s.City == "Warsaw"));
                    await botClient.SendTextMessageAsync(message.Chat.Id, warsawReport);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "was":
                    string warsawResult = subscriberService.SubscribeUnsubscribe("Warsaw", message.From.Id);
                    await botClient.SendTextMessageAsync(message.Chat.Id, warsawResult);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "wr":
                    await botClient.SendTextMessageAsync(message.Chat.Id, "==============>Wroclaw");
                    var wroclawReport = await weatherService.GetReport(subscriberService.Subscriptions.FirstOrDefault(s => s.City == "Wroclaw"));
                    await botClient.SendTextMessageAsync(message.Chat.Id, wroclawReport);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                case "wrs":
                    string wroclawResult = subscriberService.SubscribeUnsubscribe("Wroclaw", message.From.Id);
                    await botClient.SendTextMessageAsync(message.Chat.Id, wroclawResult);
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
                default:
                    await botClient.DeleteMessageAsync(message.From.Id, message.MessageId);
                    return;
            }
        }
    }
}
