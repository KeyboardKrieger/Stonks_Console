using System;
using ServiceStack.Text;
using System.Linq;
using System.Collections;
using StonksLibrary;

namespace StonksConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            StockTrading stonks = new StockTrading();
            Console.WriteLine("FreeMoney:" + stonks.User.FreeMoney);
            Console.WriteLine();

            stonks.BuyStock("AMZN", 1000);
            stonks.BuyStock("FB", 5000);
            stonks.BuyStock("AMZN", 500);
            Console.WriteLine("FreeMoney:" + stonks.User.FreeMoney);
            foreach (var entry in stonks.User.Entries)
            {
                Console.WriteLine(entry.Stock.Symbol+": "+ entry.GetActualValue());
            }
            Console.WriteLine();

            stonks.SellStock(stonks.User.Entries.First().Id);
            Console.WriteLine("FreeMoney:"+stonks.User.FreeMoney);
            foreach (var entry in stonks.User.Entries)
            {
                Console.WriteLine(entry.Stock.Symbol + ": " + entry.GetActualValue());
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
