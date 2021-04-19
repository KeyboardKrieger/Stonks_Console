using System;

namespace StonksLibrary
{
    public class StockPriceData
    {
        public DateTime Timestamp { get; set; }
        public float Open { get; set; }

        public float High { get; set; }
        public float Low { get; set; }

        public float Close { get; set; }
        public float Volume { get; set; }
    }
}
