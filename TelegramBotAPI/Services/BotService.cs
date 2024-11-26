using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotAPI.Services
{
    public class BotService
    {
        TelegramBotClient bot = new TelegramBotClient("7887221454:AAGAkdaY6j-UUKj6VwpdM_Tm5QTYRpL_Hgo");
        KeyboardButton[] asiaSites = new KeyboardButton[] { "tengrinews.kz", "somesite" };
        KeyboardButton[] americanSites = new KeyboardButton[] { "cnn.com", "dabudidabudai" };
        public async Task NewBot()
        {
            var me = await bot.GetMe();
            bot.OnMessage += OnMessage;
        }

        async Task OnMessage(Message msg, UpdateType type)
        {
            if (msg.Text is null)
                return;

            var replyMarkup = new ReplyKeyboardMarkup(true).AddButtons("Просмотр новостей", "Настройки", "Подписка");
            switch (msg.Text)
            {
                case "Просмотр новостей":
                    replyMarkup = new ReplyKeyboardMarkup(true).AddButtons("Азия", "Америка", "Назад");
                    await bot.SendMessage(msg.Chat, "Выберите регион", replyMarkup: replyMarkup);
                    return;
                case "Азия":
                    replyMarkup = new ReplyKeyboardMarkup(true).AddButtons(asiaSites);
                    await bot.SendMessage(msg.Chat, "Выберите новостной сайт", replyMarkup: replyMarkup);
                    return;
                case "Америка":
                    replyMarkup = new ReplyKeyboardMarkup(true).AddButtons(americanSites);
                    await bot.SendMessage(msg.Chat, "Выберите новостной сайт", replyMarkup: replyMarkup);
                    return;
                default:
                    await bot.SendMessage(msg.Chat, "Чем могу помочь?", replyMarkup: replyMarkup);
                    return;
            }

        }
    }
}
