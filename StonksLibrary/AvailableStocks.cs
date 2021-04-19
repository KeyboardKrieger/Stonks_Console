using System;
using System.Collections.Generic;
using System.Linq;

namespace StonksLibrary
{
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
}
