using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project3
{

    //Updated CandleStick Class Derived form original Candlestick Class
    public class SmartCandlestick : CandleStick
    {
        // Constructor
        public SmartCandlestick(DateTime date, decimal open, decimal high, decimal low, decimal close, long volume)
            : base(date, open, high, low, close, volume)
        {
        }

        // Property for the range of the whole candlestick
        public decimal Range => High - Low;

        // Property for the range from open to close
        public decimal BodyRange => Math.Abs(Close - Open);

        // Property for the larger of the open and close
        public decimal TopPrice => Math.Max(Open, Close);

        // Property for the lesser of the open and close
        public decimal BottomPrice => Math.Min(Open, Close);

        // Property for the height of the upper tail
        public decimal UpperTail => High - TopPrice;

        // Property for the height of the lower tail
        public decimal LowerTail => BottomPrice - Low;

        // Method to determine the trend of the candlestick
        public string GetTrend()
        {
            if (Open == Close && Open == High && Open == Low)
            {
                return "Marubozu";
            }
            else if (Open == Close && Open == Low && High > Open)
            {
                return "Hammer";
            }
            else if (Open == Close && Open == High && Low < Open)
            {
                return "Gravestone Doji";
            }
            else if (Open == Close && Open == Low && High == Open)
            {
                return "Dragonfly Doji";
            }
            else if (Open == Close)
            {
                return "Doji";
            }
            else if (Close > Open)
            {
                return "Bullish";
            }
            else if (Close < Open)
            {
                return "Bearish";
            }
            else
            {
                return "Neutral";
            }
        }

        // Override the DisplayInfo method to include additional information
        public new void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Range: {Range}");
            Console.WriteLine($"Body Range: {BodyRange}");
            Console.WriteLine($"Top Price: {TopPrice}");
            Console.WriteLine($"Bottom Price: {BottomPrice}");
            Console.WriteLine($"Upper Tail: {UpperTail}");
            Console.WriteLine($"Lower Tail: {LowerTail}");
            Console.WriteLine($"Trend: {GetTrend()}");
        }
    }
               

}
