using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;


namespace Project3
{
    //methods to creat,modify and manage SmartCandleStick Lists
    internal class CandleStickManager
    {
        // Method to creat SmartCandlestick list for CSV File
        public List<SmartCandlestick> LoadFromCsv(string filePath)
        {
            var candleSticks = new List<SmartCandlestick>();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    bool isFirstLine = true;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (isFirstLine)
                        {
                            isFirstLine = false;
                            continue;
                        }

                        var values = line.Split(',');

                        var date = DateTime.ParseExact(values[0].Trim('"'), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        var open = decimal.Parse(values[1]);
                        var high = decimal.Parse(values[2]);
                        var low = decimal.Parse(values[3]);
                        var close = decimal.Parse(values[4]);
                        var volume = long.Parse(values[5]);

                        var candleStick = new SmartCandlestick(date, open, high, low, close, volume);
                        candleSticks.Add(candleStick);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading the CSV file: {ex.Message}");
            }

            return candleSticks;
        }

        // Method to orders SmartCandlestick list by dates
        public List<SmartCandlestick> OrderByDate(List<SmartCandlestick> candleSticks)
        {
            return candleSticks.OrderBy(cs => cs.Date).ToList();
        }

        // Method to Removes all Smart Candlesticsk in list that are not within a specified range
        public List<SmartCandlestick> FilterByDateRange(List<SmartCandlestick> candleSticks, DateTime startDate, DateTime endDate)
        {
            return candleSticks.Where(cs => cs.Date >= startDate && cs.Date <= endDate).ToList();
        }

    

        // Method to create a list of CandleStick objects with only the base values
        public List<CandleStick> ExtractBaseValues(List<SmartCandlestick> smartCandlesticks)
        {
            return smartCandlesticks.Select(sc => new CandleStick(sc.Date, sc.Open, sc.High, sc.Low, sc.Close, sc.Volume)).ToList();
        }

        // Method to Normalize CandleStick Chart
        public static void NormalizeCandleStick(List<SmartCandlestick> data, Chart chart, string chartAreaName)
        {
            decimal minY = data.Min(candle => candle.Low);
            decimal maxY = data.Max(candle => candle.High);

            // Round the min and max Y values to the nearest whole number
            minY = Math.Floor(minY);
            maxY = Math.Ceiling(maxY);

            ChartArea chartArea = chart.ChartAreas[chartAreaName];
            chartArea.AxisY.Minimum = (double)minY;
            chartArea.AxisY.Maximum = (double)maxY;

            // Set the Y-axis interval to 5 to display whole numbers
            chartArea.AxisY.Interval = 5;

            // Configure the X-axis to handle sequential indices
            chartArea.AxisX.IntervalType = DateTimeIntervalType.Number;
            //chartArea.AxisX.Interval = 1;               
            chartArea.AxisX.LabelStyle.Format = "";
            chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
            chartArea.AxisX.IsMarginVisible = false;
            chartArea.AxisY.IsStartedFromZero = false;

            // Add data points to the chart with color settings
            Series series = new Series
            {
                ChartType = SeriesChartType.Candlestick,
                XValueType = ChartValueType.Double
            };

            for (int i = 0; i < data.Count; i++)
            {
                var candle = data[i];
                var dataPoint = new DataPoint
                {
                    XValue = i, // Use sequential index
                    YValues = new double[] { (double)candle.Low, (double)candle.High, (double)candle.Open, (double)candle.Close }
                };

                // Set color based on price movement
                if (candle.Close > candle.Open)
                {
                    dataPoint.Color = System.Drawing.Color.Green;
                    dataPoint.BackSecondaryColor = System.Drawing.Color.Red;
                }
                else
                {
                    dataPoint.Color = System.Drawing.Color.Red;
                    dataPoint.BackSecondaryColor = System.Drawing.Color.Red;
                }

                series.Points.Add(dataPoint);
            }

            chart.Series.Clear();
            chart.Series.Add(series);

           
            // Set custom labels for the X-axis to display the correct dates
            chartArea.AxisX.CustomLabels.Clear();

            int maxLabels = 30; // Maximum number of labels to display
            int dataCount = data.Count;
            int interval = Math.Max(1, dataCount / maxLabels);

            for (int i = 0; i < dataCount; i += interval)
            {
                var candle = data[i];
                CustomLabel label = new CustomLabel
                {
                    FromPosition = i - 0.5,
                    ToPosition = i + 0.5,
                    Text = candle.Date.ToString("dd-MM-yyyy")
                };
                chartArea.AxisX.CustomLabels.Add(label);
            }

            // Ensure the last label is added
            if (dataCount % interval != 0)
            {
                var lastCandle = data[dataCount - 1];
                CustomLabel lastLabel = new CustomLabel
                {
                    FromPosition = dataCount - 1 - 0.5,
                    ToPosition = dataCount - 1 + 0.5,
                    Text = lastCandle.Date.ToString("dd-MM-yyyy")
                };
                chartArea.AxisX.CustomLabels.Add(lastLabel);
            }

            // Ensure the last label is added if it's not already included
            if (dataCount % interval != 0)
            {
                var candle = data[dataCount - 1];
                CustomLabel label = new CustomLabel
                {
                    FromPosition = dataCount - 1 - 0.5,
                    ToPosition = dataCount - 1 + 0.5,
                    Text = candle.Date.ToString("dd-MM-yyyy")
                };
                chartArea.AxisX.CustomLabels.Add(label);
            }

            // Set the interval for the X-axis ticks to match the label interval
            chartArea.AxisX.Interval = interval;
            // Set the labels to display horizontally
            chartArea.AxisX.LabelStyle.Angle = 0;
            chartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 8);


        }
        
    }
    
}
