using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;

namespace TelegramBotAPI.Services
{
    public class BotService
    {
        TelegramBotClient bot = new TelegramBotClient("7887221454:AAGAkdaY6j-UUKj6VwpdM_Tm5QTYRpL_Hgo");
        public async Task NewBot()
        {
            var me = await bot.GetMe();
            bot.OnMessage += OnMessage;
        }

        async Task OnMessage(Message msg, UpdateType type)
        {
            if (msg.Text is null) return;   
            await bot.SendMessage(msg.Chat, $"{msg.From} said: {msg.Text}");
        }
    }
}
