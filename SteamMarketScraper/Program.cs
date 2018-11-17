using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamMarketScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            //Call scraperStarter
            Operations operations = new Operations();
            operations.ScraperStarter();
        }
    }
}
