using System;
using System.Collections.Generic;
using ServiceStack;

namespace StonksConsole
{
    class AlphaVantageSDK
    {
        private string ApiKey = "1WPNC1AKHPJDXJD9";

        public List<StockPriceData> GetDailyPriceData(string symbol)
        {
            String Connectionstring = $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={symbol}&apikey={ApiKey}&datatype=csv";
            var returnStringFromApi = Connectionstring.GetStringFromUrl();
           var daylyPrices = returnStringFromApi.FromCsv<List<StockPriceData>>();

            return daylyPrices;
        }
    }
}
