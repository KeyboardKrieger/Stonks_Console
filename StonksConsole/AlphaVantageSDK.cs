using System;
using System.Collections.Generic;
using ServiceStack;

namespace StonksConsole
{
    class AlphaVantageSDK
    {
        private string ApiKey = "demo";

        public List<StockPriceData> GetDailyPriceData(string symbol)
        {
            String Connectionstring = $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={symbol}&apikey={ApiKey}&datatype=csv";
            
           var daylyPrices = Connectionstring.GetStringFromUrl().FromCsv<List<StockPriceData>>();

            return daylyPrices;
        }
    }
}
