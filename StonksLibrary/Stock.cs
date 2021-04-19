using System.Linq;
using System.Collections.Generic;

namespace StonksLibrary
{
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
