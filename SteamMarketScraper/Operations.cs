using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamMarketScraper
{
    class Operations
    {
        public IWebDriver driver;

        public void ScraperStarter()
        {
            OpenBrowser();

            //Go to CSGO's marketplace
            driver.Navigate().GoToUrl("https://steamcommunity.com/market/search?appid=730#p1_price_asc");

            //Wait two seconds so that the webpage has time to load
            System.Threading.Thread.Sleep(4000);

            //Search for the products' names
            IList<IWebElement> productList = driver.FindElements(By.CssSelector(".market_listing_item_name"));
            IList<IWebElement> imgLinkList = driver.FindElements(By.CssSelector(".market_listing_item_img"));
            string[] imgSrcList = new string[imgLinkList.Count];

            Console.WriteLine("productList: " + productList.Count);
            Console.WriteLine("imgLinkList: " + imgLinkList.Count);
            Console.WriteLine("imgSrcList: " + imgSrcList.Length);

            for (int i = 0; i < imgSrcList.Length; i++)
            {
                imgSrcList[i] = imgLinkList[i].GetAttribute("src");

                OpenBrowser();

                driver.Navigate().GoToUrl(imgSrcList[i]);

                CloseBrowser();
            }

            Console.Read();    
        }



        public void OpenBrowser()
        {
            //New browser
            driver = new ChromeDriver();
        }



        public void CloseBrowser()
        {
            //Close the browser
            driver.Close();
        }
    }
}