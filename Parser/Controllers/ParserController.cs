using Microsoft.AspNetCore.Mvc;

namespace Parser.Controllers
{
    public class ParserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
