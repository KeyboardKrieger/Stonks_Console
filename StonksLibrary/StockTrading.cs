using System;

namespace StonksLibrary
{
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
}
