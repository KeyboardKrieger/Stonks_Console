using System;

namespace StonksLibrary
{
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
}
