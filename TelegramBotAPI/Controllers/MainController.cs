using Microsoft.AspNetCore.Mvc;
using TelegramBotAPI.Services;

namespace TelegramBotAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MainController : Controller
    {
        BotService botService;

        public MainController(BotService botService)
        {
            this.botService = botService;
        }

        [HttpGet]
        public async Task<string> Index()
        {
            await botService.NewBot();
            return "nice work";
        }
    }
}
