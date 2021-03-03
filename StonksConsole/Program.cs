using System;
using System.Collections.Generic;
using ServiceStack.Text;

namespace StonksConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            AlphaVantageSDK alpha = new AlphaVantageSDK();
            var prices = alpha.GetDailyPriceData("IBM");
            prices.PrintDump();
            List<Schueler> schl = new List<Schueler>()
            {
                new Schueler("fafas", "13", prices[0]),
                new Schueler("fafas", "13", prices[1])
            };
            schl.PrintDump();

            Console.ReadKey();
        }
    }
    class Schueler
    {
        public Schueler(string n, string k, StockPriceData stock)
        {
            name = n;
            klasse = k;
            stocks = stock;
        }
        public string name { get; set; }
        public StockPriceData stocks { get; set;}
        public string klasse { get; set; }
    }
    class LineCalculator
    {
        public List<Line> Lines = new List<Line>();
        public void AddLine(Vector2 startPoint, float rise)
        {
            if (Lines == null)
                Lines = new List<Line>();

            Lines.Add(new Line(startPoint, rise));
        }
        public IEnumerator<float> GetYValues(float x)
        {
            foreach (var line in Lines)
            {
                yield return line.GetYforX(x);
            }
        }
    }
    class Line
    {
        private Vector2 StartPoint;
        private float Rise;

        public Line(Vector2 startPoint, float rise)
        {
            StartPoint = startPoint;
            Rise = rise;
        }
        public float GetYforX(float x)
        {
            var xDistance = x - StartPoint.X;
            float yValue = xDistance * Rise + StartPoint.Y;

            return yValue;
        }
    }
    class Vector2
    {
        public float X;
        public float Y;
    }
}
