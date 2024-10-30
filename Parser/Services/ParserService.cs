using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Parser.Context;

namespace Parser.Services
{
    public class ParserService
    {
        IWebDriver driver;
        private EFDbContext context;
        string defaultPage;
        public ParserService(EFDbContext context)
        {
            this.context = context;
            driver = new ChromeDriver();
            defaultPage = driver.CurrentWindowHandle;
        }

        public async Task StartKZParse()
        {
            driver.Navigate().GoToUrl("tengrinews.kz");
        }
    }
}
