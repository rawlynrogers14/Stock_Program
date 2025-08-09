using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project3
{ 
    //Methods to select and manage Fibboacci level related operation     
    internal class SelectionManager
    {
        //Class Varables 
        private Chart chart;
        private Rectangle selectionRectangle;
        private Rectangle selectionBox;
        private List<DataPoint> selectedPoints;

        //Class Constructors
        public SelectionManager(Chart chart)
        {
            this.chart = chart;
        }       
        public void SetSelectionRectangle(Rectangle selectionRectangle)
        {
            this.selectionRectangle = selectionRectangle;
        }

        //Methode to take user slected bounds, and creates a list of candlestick       
        public List<SmartCandlestick> SelectCandlesticksInRectangle()
        {
            var area = chart.ChartAreas[0];
            double xMin = area.AxisX.PixelPositionToValue(selectionRectangle.Left);
            double xMax = area.AxisX.PixelPositionToValue(selectionRectangle.Right);

            List<SmartCandlestick> selectedCandlesticks = new List<SmartCandlestick>();
            selectedPoints = new List<DataPoint>();

            foreach (var series in chart.Series)
            {
                foreach (var point in series.Points)
                {
                    if (point.XValue >= xMin && point.XValue <= xMax)
                    {
                        DateTime date = DateTime.FromOADate(point.XValue);
                        decimal open = (decimal)point.YValues[0]; // Adjust based on your data
                        decimal high = (decimal)point.YValues[1]; // Adjust based on your data
                        decimal low = (decimal)point.YValues[2]; // Adjust based on your data
                        decimal close = (decimal)point.YValues[3]; // Adjust based on your data
                        long volume = 0; // Adjust based on your data

                        var candleStick = new SmartCandlestick(date, open, high, low, close, volume);
                        selectedCandlesticks.Add(candleStick);
                        selectedPoints.Add(point);

                    }

                }
            }

            
            CalculateSelectionBox();
            chart.Invalidate(); // Forces the chart to redraw with the selection box

            return selectedCandlesticks;
        }

        //Methode to take user slected candlesticks, and creates a list of candlestick
        //that are a valed wave within what was slected.
        private void CalculateSelectionBox()
        {
            if (selectedPoints.Count < 2)
            {
                selectionBox = Rectangle.Empty; // Not enough points to form a box
                Console.WriteLine("Not enough points to form a selection box.");
                return;
            }

            // Find the highest peak and the lowest valley in the selected points
            var highestPeak = selectedPoints.OrderByDescending(p => new[] { p.YValues[0], p.YValues[1], p.YValues[2], p.YValues[3] }.Max()).First();
            var lowestValley = selectedPoints.OrderBy(p => new[] { p.YValues[0], p.YValues[1], p.YValues[2], p.YValues[3] }.Min()).First();

            // Determine the range of points to keep
            int startIndex = selectedPoints.IndexOf(highestPeak);
            int endIndex = selectedPoints.IndexOf(lowestValley);

            if (startIndex > endIndex)
            {
                // Swap startIndex and endIndex if highestPeak comes after lowestValley
                int temp = startIndex;
                startIndex = endIndex;
                endIndex = temp;
            }

            // Filter the selectedPoints list to include only the points within the range
            selectedPoints = selectedPoints.Skip(startIndex).Take(endIndex - startIndex + 1).ToList();
                        

            DataPoint leftEdge = selectedPoints.First();
            DataPoint rightEdge = selectedPoints.Last();

            var area = chart.ChartAreas[0];
            double leftX = area.AxisX.ValueToPixelPosition(leftEdge.XValue);
            double rightX = area.AxisX.ValueToPixelPosition(rightEdge.XValue);
            double topY = area.AxisY.ValueToPixelPosition(new[] { highestPeak.YValues[0], highestPeak.YValues[1], highestPeak.YValues[2], highestPeak.YValues[3] }.Max());
            double bottomY = area.AxisY.ValueToPixelPosition(new[] { lowestValley.YValues[0], lowestValley.YValues[1], lowestValley.YValues[2], lowestValley.YValues[3] }.Min());

            
            if (leftX == rightX || topY == bottomY)
            {
                selectionBox = Rectangle.Empty; // No valid selection box
                
            }
            else
            {
                selectionBox = new Rectangle((int)leftX, (int)topY, (int)(rightX - leftX), (int)(bottomY - topY));
                
            }


        }
        //Methode to uses to draw the Calculate Selection Box on the Chart
        public void DrawSelectionBox(Graphics g)
        {
            if (!selectionBox.IsEmpty)
            {
                using (Pen pen = new Pen(Color.Blue, 2))
                {
                    g.DrawRectangle(pen, selectionBox);
                }

                DrawFibonacciLevels(g);
            }
        }
        //Methode to uses to draw the Calculate fibonacci Levles of Selection Box on the Chart
        private void DrawFibonacciLevels(Graphics g)
        {
            if (selectionBox.IsEmpty)
            {
                return;
            }

            var area = chart.ChartAreas[0];
            double topYValue = area.AxisY.PixelPositionToValue(selectionBox.Top);
            double bottomYValue = area.AxisY.PixelPositionToValue(selectionBox.Bottom);

            // Determine if the right edge is the smallest value in the range
            DataPoint rightEdge = selectedPoints.OrderByDescending(p => p.XValue).First();
            double rightEdgeMinValue = new[] { rightEdge.YValues[0], rightEdge.YValues[1], rightEdge.YValues[2], rightEdge.YValues[3] }.Min();
            double selectedMinValue = selectedPoints.Min(p => new[] { p.YValues[0], p.YValues[1], p.YValues[2], p.YValues[3] }.Min());

            bool isRightEdgeSmallest = rightEdgeMinValue == selectedMinValue;

            double[] fibonacciLevels = { 0.0, 0.236, 0.382, 0.5, 0.628, 0.764, 1.0 };

            foreach (double level in fibonacciLevels)
            {
                double yValue;
                if (isRightEdgeSmallest)
                {
                    yValue = bottomYValue + level * (topYValue - bottomYValue);
                }
                else
                {
                    yValue = topYValue - level * (topYValue - bottomYValue);
                }

                double yPixel = area.AxisY.ValueToPixelPosition(yValue);

                using (Pen pen = new Pen(Color.Blue, 2))
                {
                    g.DrawLine(pen, selectionBox.Left, (int)yPixel, selectionBox.Right + 10, (int)yPixel); // Extend the line slightly past the box
                }

                using (Font font = new Font("Arial", 12, FontStyle.Bold))
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    g.DrawString($"{level * 100}%", font, brush, selectionBox.Right + 12, (int)yPixel - 6); // Mark the percentage on the line
                }
                                
            }           


        }
        //Methode to uses to Calculate Fibonacci Levels of specified range and return a beauty value
        public int CalculateBeauty(double topYValue, double bottomYValue, List<DataPoint> selectedPoints, Rectangle selectionBox, Chart chart)
        {
            if (selectionBox.IsEmpty)
            {
                Console.WriteLine("No selection box to calculate beauty.");
                return 0;
            }

            var area = chart.ChartAreas[0];
            double leftXValue = area.AxisX.PixelPositionToValue(selectionBox.Left);
            double rightXValue = area.AxisX.PixelPositionToValue(selectionBox.Right);

            double[] fibonacciLevels = { 0.0, 0.236, 0.382, 0.5, 0.628, 0.764, 1.0 };
            int count = 0;

            foreach (var point in selectedPoints)
            {
                if (point.XValue >= leftXValue && point.XValue <= rightXValue)
                {
                    decimal[] prices = { (decimal)point.YValues[0], (decimal)point.YValues[1], (decimal)point.YValues[2], (decimal)point.YValues[3] };

                    foreach (double level in fibonacciLevels)
                    {
                        double yValue = bottomYValue + level * (topYValue - bottomYValue);
                        decimal fibLevel = (decimal)yValue;

                        foreach (var price in prices)
                        {
                            if (Math.Abs(price - fibLevel) / price <= 0.0125m)
                            {
                                count++;
                                
                            }
                        }
                    }
                }
            }

            chart.Invalidate(); // Refresh the chart            
            return count;
        }
        //Methode to generate a list of {prices , beauty} values based on the selection box 
        public List<BeautyData> GenerateBeautyList(List<DataPoint> selectedPoints, Rectangle selectionBox, Chart chart)
        {
            if (selectionBox.IsEmpty)
            {
                Console.WriteLine("No selection box to calculate beauty.");
                return new List<BeautyData>();
            }

            var area = chart.ChartAreas[0];
            double topYValue = area.AxisY.PixelPositionToValue(selectionBox.Top);
            double bottomYValue = area.AxisY.PixelPositionToValue(selectionBox.Bottom);

            DataPoint leftEdge = selectedPoints.First();
            DataPoint rightEdge = selectedPoints.Last();

            double leftEdgeMax = new[] { leftEdge.YValues[0], leftEdge.YValues[1], leftEdge.YValues[2], leftEdge.YValues[3] }.Max();
            double leftEdgeMin = new[] { leftEdge.YValues[0], leftEdge.YValues[1], leftEdge.YValues[2], leftEdge.YValues[3] }.Min();
            double rightEdgeMax = new[] { rightEdge.YValues[0], rightEdge.YValues[1], rightEdge.YValues[2], rightEdge.YValues[3] }.Max();
            double rightEdgeMin = new[] { rightEdge.YValues[0], rightEdge.YValues[1], rightEdge.YValues[2], rightEdge.YValues[3] }.Min();

            bool isZeroAtBottom = leftEdgeMax > rightEdgeMax && rightEdgeMin < leftEdgeMin;

            double incrementPoint = RoundUpToNearestHalf((topYValue - bottomYValue) / 20);
            topYValue = RoundUpToNearestHalf(topYValue);
            bottomYValue = RoundUpToNearestHalf(bottomYValue);
            List<BeautyData> beautyList = new List<BeautyData>();

            for (int i = 0; i < 50; i++)
            {
                double newTopYValue, newBottomYValue;
                if (isZeroAtBottom)
                {
                    newBottomYValue = bottomYValue - i * incrementPoint;
                    newTopYValue = topYValue;
                }
                else
                {
                    newBottomYValue = bottomYValue;
                    newTopYValue = topYValue + i * incrementPoint;
                }

                int beautyValue = CalculateBeauty(newTopYValue, newBottomYValue, selectedPoints, selectionBox, chart);
                beautyList.Add(new BeautyData { Price = isZeroAtBottom ? newBottomYValue : newTopYValue, BeautyValue = beautyValue });
            }

            return beautyList;
        }
        //Methode that returns a double value rouned to the nearest .5
        private double RoundUpToNearestHalf(double value)
        {
            return Math.Round(value * 2) / 2;
        }
        //Get Method that calls generateBeautyList and retures a Beauty list
        public List<BeautyData> GetBeautyList()
        {
            if (selectionBox.IsEmpty)
            {
                return new List<BeautyData>();
            }

            return GenerateBeautyList(selectedPoints, selectionBox, chart);
        }
        //Methode that clears Selection Box from Chart.
        public void ClearSelectionBox()
        {
            if (!selectionBox.IsEmpty)
            {
                selectionBox = Rectangle.Empty; // Clear the selection box
                chart.Invalidate(); // Refresh the chart to remove the selection box

            }
        }

    }
}














