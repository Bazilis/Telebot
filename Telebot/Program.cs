using Telebot.Services;
using Telegram.Bot;

namespace Telebot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            builder.Services.AddSingleton<WeatherService>();
            builder.Services.AddSingleton<UserStateService>();
            builder.Services.AddScoped<HandleUpdateService>();
            builder.Services.AddHostedService<WebhookService>();
            builder.Services.AddHttpClient("TgWebhook")
                    .AddTypedClient<ITelegramBotClient>(httpClient
                        => new TelegramBotClient(Environment.GetEnvironmentVariable("BotToken"), httpClient));
                        //=> new TelegramBotClient(builder.Configuration["BotToken"], httpClient));
            
            builder.Services.AddHttpClient("OpenWeatherApi", c =>
            {
                //c.BaseAddress = new Uri(builder.Configuration["WebApi"]);
                c.DefaultRequestHeaders.Add("Accept", "*/*");
                c.DefaultRequestHeaders.Add("User-Agent", "OpenWeatherApi");
            });

            builder.Services.AddHostedService<DataSenderService>();
            builder.Services.AddHostedService<AwakeService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
