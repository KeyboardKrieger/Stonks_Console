using System;
using System.Collections.Generic;
using System.Linq;

namespace StonksLibrary
{
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
}
