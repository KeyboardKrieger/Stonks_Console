using System;
using ServiceStack.Text;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

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
    public class StockTrading
    {
        public AvailableStocks Stocks;
        public Portfolio User;

        public StockTrading()
        {
            Stocks = new AvailableStocks();
            User = new Portfolio();
        }
        public void BuyStock(string symbol, float value)
        {
            var stock = Stocks.GetStock(symbol);
            if (stock == null)
                return;

            User.BuyStock(stock, value);
        }
        public void SellStock(Guid id)
        {
            User.SellStock(id);
        }
    }
    public class Portfolio
    {
        public float FreeMoney { get; private set; }
        public List<PortfolioEntry> Entries { get; private set; }
        public Portfolio(float startMoney = 10000)
        {
            Entries = new List<PortfolioEntry>();
            FreeMoney = startMoney;
        }
        public float GetBalance()
        {
            var balance = FreeMoney;
            foreach (var entry in Entries)
            {
                balance += entry.GetActualValue();
            }
            return balance;
        }
        public void AddMoney(float money)
        {
            if (money < 0)
                return;

            FreeMoney += money;
        }
        public void TakeMoney(float money)
        {
            if (money < 0)
                return;

            FreeMoney -= money;
        }
        public void BuyStock(Stock stock, float value)
        {
            if (FreeMoney < value)
                return;

            var count = value / stock.ActualPrice;
            Entries.Add(new PortfolioEntry(stock, count));
            FreeMoney -= value;
        }
        public void SellStock(Guid id)
        {
            var entrieWithStock = Entries.First(x => x.Id == id);
            if (entrieWithStock == null)
                return;

            FreeMoney += entrieWithStock.GetActualValue();
            Entries.Remove(entrieWithStock);
        }
    }
    public class PortfolioEntry
    {
        public Guid Id { get; private set; }
        public Stock Stock { get; private set; }
        DateTime BuyDate;
        float BuyPrice;
        float StockCount;

        public PortfolioEntry(Stock stock, float count)
        {
            Id = Guid.NewGuid();
            Stock = stock;
            BuyDate = DateTime.Today;
            BuyPrice = stock.ActualPrice;
            StockCount = count;
        }
        public float GetActualValue()
        {
            return Stock.ActualPrice * StockCount;
        }
    }
    public class AvailableStocks
    {
        HashSet<Stock> Stocks;
        public AvailableStocks()
        {
            Stocks = new HashSet<Stock>();
            List<String> symbols = new List<string>()
            {
                "AMZN","FB"
            };

            foreach (var symbol in symbols)
            {

                Stocks.Add(new Stock(symbol));
            }
        }
        public Stock GetStock(string symbol)
        {
            if (symbol == null)
                return null;

            return Stocks.First(x => x.Symbol == symbol);
        }
    }
    public class Stock
    {
        public string Symbol { get; private set; }
        public float ActualPrice { get; private set; }
        public List<StockPriceData> PriceData { get; private set; }
        public Stock(string symbol)
        {
            AlphaVantageSDK sdk = new AlphaVantageSDK();
            Symbol = symbol;
            PriceData = sdk.GetDailyPriceData(symbol);
            ActualPrice = PriceData.OrderBy(x => x.Timestamp).First().Close;
        }
    }
}
