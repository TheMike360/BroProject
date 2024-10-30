using Parser.Services;
using System.Web.Http;

namespace Parser.Controllers
{
    public class ParserController : ApiController
    {
        private ParserService parseService;
        public ParserController(ParserService parseService)
        {
            this.parseService = parseService;
        }
        public ParserController() {
            }

        public async Task<string> TestParse()
        {
            await parseService.StartKZParse();
            return "ok";
        }
    }
}
