using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    //Base CandleStick Class
    public class CandleStick
    {
        // Properties
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public long Volume { get; set; }

        // Constructor
        public CandleStick(DateTime date, decimal open, decimal high, decimal low, decimal close, long volume)
        {
            Date = date;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
        }

        // Method to display candlestick information
        public void DisplayInfo()
        {
            Console.WriteLine($"Date: {Date.ToShortDateString()}");
            Console.WriteLine($"Open: {Open}");
            Console.WriteLine($"High: {High}");
            Console.WriteLine($"Low: {Low}");
            Console.WriteLine($"Close: {Close}");
            Console.WriteLine($"Volume: {Volume}");
        }
    }

}
