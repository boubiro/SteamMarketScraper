using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;
using System.IO;
using System.Drawing.Imaging;

namespace SteamMarketScraper
{
    class Operations
    {
        public IWebDriver driver;

        public void ScraperStarter()
        {
            IWebDriver OGDriver = new ChromeDriver();

            //Go to CSGO's marketplace
            OGDriver.Navigate().GoToUrl("https://steamcommunity.com/market/search?appid=730#p1_price_asc");

            //Wait two seconds so that the webpage has time to load
            System.Threading.Thread.Sleep(2000);

            //Search for the products' names
            IList<IWebElement> productList = OGDriver.FindElements(By.CssSelector(".market_listing_item_name"));
            IList<IWebElement> imgLinkList = OGDriver.FindElements(By.CssSelector(".market_listing_item_img"));
            string[] imgSrcList = new string[imgLinkList.Count];

            Console.WriteLine("productList: " + productList.Count);
            Console.WriteLine("imgLinkList: " + imgLinkList.Count);
            Console.WriteLine("imgSrcList: " + imgSrcList.Length);

            int productNumber = 0;

            for(int i = 0; i < imgSrcList.Length; i++)
            {
                imgSrcList[i] = imgLinkList[i].GetAttribute("src");
                OpenBrowser();
                driver.Navigate().GoToUrl(imgSrcList[i]);
                WebClient webClient = new WebClient();
                webClient.DownloadFile(imgSrcList[i], "a" + productNumber + ".jpeg");
                productNumber++;
                CloseBrowser();
            }

            OGDriver.Close();

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


    //Make the code have comments

    //Be sure to not get chrome to download anything



