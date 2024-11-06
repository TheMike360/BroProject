using Microsoft.AspNetCore.Mvc;
using Parser.Services;

namespace Parser.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KZParserController : ControllerBase
    {
        private ParserService parseService;
        public KZParserController(ParserService parseService)
        {
            this.parseService = parseService;
        }

        [HttpPost]
        public async Task<string> TengriParse()
        {
            await parseService.StartTengriParse();
            return "ok";
        }
    }
}
