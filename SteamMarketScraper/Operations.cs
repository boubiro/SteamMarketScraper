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
            //Make a new special driver reference just for the marketplace
            IWebDriver OGDriver = new ChromeDriver();

            //Go to CSGO's marketplace
            OGDriver.Navigate().GoToUrl("https://steamcommunity.com/market/search?appid=730#p1_price_asc");

            //Wait two seconds so that the webpage has time to load
            System.Threading.Thread.Sleep(2000);

            //Search for the products' names
            //Search for the product's image
            //Make a new empty array with the length of productImgList
            IList<IWebElement> productNameList = OGDriver.FindElements(By.CssSelector(".market_listing_item_name"));
            IList<IWebElement> productImgList = OGDriver.FindElements(By.CssSelector(".market_listing_item_img"));
            string[] imgSrcList = new string[productImgList.Count];

            int productNumber = 0;

            for(int i = 0; i < imgSrcList.Length; i++)
            {
                //Get the "src" (aka URL) from the image
                imgSrcList[i] = productImgList[i].GetAttribute("src");

                OpenBrowser();

                //Navigate to the image's url
                driver.Navigate().GoToUrl(imgSrcList[i]);

                WebClient webClient = new WebClient();

                //Download the image
                webClient.DownloadFile(imgSrcList[i], "a" + productNumber + ".png");

                //Add 1 to the product number
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


    //Be sure to not get chrome to download anything



