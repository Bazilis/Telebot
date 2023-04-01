using Telebot.Dto;
using Telebot.Commands;
using Telebot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Telebot.Handlers
{
    public class CallbackQueryHandler
    {
        public static async Task HandleAsync(CallbackQuery callback, ITelegramBotClient botClient, UserStateService userStateService, WeatherService weatherService)
        {
            var userState = userStateService.GetUserStateByUserIdAsync(callback.From.Id);

            if (userState == null)
            {
                userState = new UserStateDto { UserId = callback.From.Id };
                userStateService.AddUserState(userState);
            }

            if (callback.Data.Length > 5 && callback.Data.Substring(0, 5).Equals("data:"))
            {
                var data = callback.Data.Split(":");
                userState.UserState = (UserStateEnum)Enum.Parse(typeof(UserStateEnum), data[1]);
                callback.Data = data[2];
            }

            switch (userState.UserState)
            {
                case UserStateEnum.NoState:
                    userState.LastCommand = callback.Data;
                    switch (callback.Data)
                    {
                        case "Back":
                            await StartCommand.ExecuteAsync(callback, botClient, userState);
                            userState.UserState = UserStateEnum.SelectingAction;
                            return;

                        case "Close":
                            await CloseCommand.ExecuteAsync(callback, botClient);
                            return;

                        default:
                            await CloseCommand.ExecuteAsync(callback, botClient);
                            return;
                    }

                case UserStateEnum.SelectingAction:
                    userState.LastCommand = callback.Data;
                    switch (callback.Data)
                    {
                        case "Get Current Data":
                            await SendCitiesCommand.ExecuteAsync(callback, botClient);
                            userState.UserState = UserStateEnum.SelectingCityForCurrentData;
                            return;

                        case "Subscriptions":
                            await SendCitiesSubscriptionsCommand.ExecuteAsync(callback, botClient, userStateService);
                            userState.UserState = UserStateEnum.SelectingCityForSubscription;
                            return;

                        case "Air Quality Info":
                            await SendAirQualityInfoCommand.ExecuteAsync(callback, botClient);
                            userState.UserState = UserStateEnum.NoState;
                            return;

                        case "Select timezone":
                            await SendTimezonesCommand.ExecuteAsync(callback, botClient, userState);
                            userState.UserState = UserStateEnum.SelectingTimezone;
                            return;

                        default:
                            await CloseCommand.ExecuteAsync(callback, botClient);
                            return;
                    }

                case UserStateEnum.SelectingCityForCurrentData:
                    await SendCurrentDataCommand.ExecuteAsync(callback, botClient, userStateService, weatherService);
                    userState.LastCommand = callback.Data;
                    userState.UserState = UserStateEnum.NoState;
                    return;

                case UserStateEnum.SelectingCityForSubscription:
                    SubscribeUserToCityCommand.ExecuteAsync(callback, userStateService);
                    await SendCitiesSubscriptionsCommand.ExecuteAsync(callback, botClient, userStateService);
                    userState.LastCommand = callback.Data;
                    userState.UserState = UserStateEnum.SelectingCityForSubscription;
                    return;

                case UserStateEnum.SelectingTimezone:
                    SetUserTimezoneCommand.ExecuteAsync(callback, userStateService);
                    await SendTimezonesCommand.ExecuteAsync(callback, botClient, userState);
                    userState.LastCommand = callback.Data;
                    userState.UserState = UserStateEnum.SelectingTimezone;
                    return;
            }
        }
    }
}
