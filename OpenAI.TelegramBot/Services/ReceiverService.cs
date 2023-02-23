using OpenAI.TelegramBot.Abstract;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace OpenAI.TelegramBot.Services;

public class ReceiverService : ReceiverServiceBase<IUpdateHandler>
{
    public ReceiverService(
        ITelegramBotClient botClient,
        IUpdateHandler updateHandler,
        ILogger<ReceiverServiceBase<IUpdateHandler>> logger)
        : base(botClient, updateHandler, logger)
    {
    }
}
