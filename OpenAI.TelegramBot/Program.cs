using Microsoft.Extensions.Options;
using OpenAI.Lib.Abstractions;
using OpenAI.TelegramBot;
using OpenAI.TelegramBot.Abstract;
using OpenAI.TelegramBot.Services;
using Telegram.Bot;
using Telegram.Bot.Polling;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.Configure<TelegramSettings>(builder.Configuration.GetRequiredSection("TelegramSettings"));
services.AddHttpClient("telegram_bot_client")
    .AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
    {
        var botConfig = sp.GetRequiredService<IOptions<TelegramSettings>>().Value;
        TelegramBotClientOptions options = new(botConfig.Token);
        return new TelegramBotClient(options, httpClient);
    });

services.AddScoped<IUpdateHandler, UpdateHandler>();
services.AddScoped<ReceiverService>();
services.AddHostedService<PollingService>();
services.AddOpenAI(builder.Configuration);
builder.Services.AddScoped<IEndpointProvider, EndpointProvider>();
services.AddControllers();
services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
}

app.UseAuthorization();

app.MapControllers();

app.Run();