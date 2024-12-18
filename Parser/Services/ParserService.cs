﻿using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Domain.Context;
using Domain.Entity;
using Domain.Enums;
using System.Collections.ObjectModel;
using System.Text;

namespace Parser.Services
{
    public class ParserService
    {
        private EFDbContext context;
        public ParserService(EFDbContext context)
        {
            this.context = context;
        }

        #region KZ
        public async Task StartTengriParse()
        {
            IWebDriver driver = new ChromeDriver();
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.Navigate().GoToUrl("https://tengrinews.kz/");
                var navLink = driver.FindElement(By.XPath("/html/body/div[@class='my-app']/main[@class='container']/div[@class='menu']/div[@class='menu_nav']/a[@class='menu_nav_item'][1]"));
                navLink.Click();
                var getNews = driver.FindElement(By.ClassName("content_main")).FindElements(By.ClassName("content_main_item"));
                var newsCont = getNews.Count();

                var getSecondHalfNews = driver.FindElements(By.XPath("/html/body/div[@class='my-app']/main[@class='container']/section[@class='first'][2]/div[@class='content rubric']/div[@class='content_main']/div[@class='content_main_item']"));

                List<ParsedData> datas = new List<ParsedData>();
                await ParseNewData(driver, getNews, datas);
                await ParseNewData(driver, getSecondHalfNews, datas);

                await context.AddRangeAsync(datas);
                await context.SaveChangesAsync();

                driver.Close();
            }
            catch (Exception ex)
            {
                driver.Close();
            }

        }

        private async Task ParseNewData(IWebDriver driver, ReadOnlyCollection<IWebElement> getNews, List<ParsedData> datas)
        {
            foreach (var item in getNews)
            {
                var newsLinkHeader = item.FindElement(By.ClassName("content_main_item_title")).FindElement(By.TagName("a"));
                var newsHeader = newsLinkHeader.Text;

                if (await context.ParsedDatas.AnyAsync(x => x.HeaderText == newsHeader))
                    continue;

                ParsedData newData = new ParsedData()
                {
                    Countries = CountriesEnum.Kz,
                    HeaderText = newsHeader,
                    SourceUrl = "https://tengrinews.kz/",
                    Time = DateTime.Now,
                    Category = "",
                    CategoryId = CategoryEnum.Other
                };

                newsLinkHeader.Click();
                Thread.Sleep(500);

                var textPTags = driver.FindElement(By.ClassName("content_main_text")).FindElements(By.TagName("p"));
                StringBuilder pStrings = new StringBuilder();
                pStrings.Append(driver.FindElement(By.ClassName("content_main_desc")).FindElement(By.TagName("p")).Text);
                foreach (var p in textPTags)
                {
                    pStrings.Append(p.Text);
                }

                newData.PostText = pStrings.ToString();
                driver.Navigate().Back();
                Thread.Sleep(500);

                datas.Add(newData);
            }
        }

        #endregion
    }
}
