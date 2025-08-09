// Rawlyn Rogers U7698-6140
// Project 3(Stock Analysis – updated of Project2)
// Project Start Date: Nov 30 2024
// Project Submission Date: Dec 06 2024
// Software System Development In C#
// COP 4365, 002
//
// New features:
//	    - Click And Drag Selection for Fibonacci Analysis
//	    - Beauty analysis with Fibonacci Levels 
//		- Beauty Class {Price value , Beauty value}
// Fibonacci Analysis
// 	    - Uses Fibonacci Levels {0%, 23.6%, 38.2%, 50%, 62.8%, 76.4%, 100%}
// 	    - Display level within selected wave
// Beauty Analysis
//	    -Starting from the 0% of selected wave to analyze increments up or down to calculate 
//       Beauty of future prices. Those values are Displayed in a chart below the candlestick chart.
//
// This program organizes Stock data from a CSV File(S) and Display
// it in the from of a Candlestick Chart. As well as a volume chart. 
// New Form Windows are created for each new file selected after the first one.
// The first file selected updates the original Form Window.
// When displaying daily data there are no Gaps in charts for weekends or holidays 
// Use can select a wave on a chat to analyze, the select wave displays the Fibonacci levels and 
// Beauty analysis of Future prices.
// Each time a load and update occurs the selected wave and beauty chat is cleared. 
//
// ****Parts of this code was generated using AI****
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project3
{
    public partial class Form_InputAndDisplay : Form
    {
        //Create Varbles for Form_InputAndDisplay
        private List<SmartCandlestick> loadedCandleSticksList;
        private List<SmartCandlestick> orderCandleSticksList;
        private List<SmartCandlestick> filteredCandleStickList;
        private Point selectionStart;
        private Rectangle selectionRectangle;
        private bool isSelecting;
        private SelectionManager selectionManager;
        

        public Form_InputAndDisplay()
        {
            
            InitializeComponent();
            selectionManager = new SelectionManager(this.chart_CandleStick);

        }

        //Constructor for Newly creaded window Forms
        public Form_InputAndDisplay(DateTime StartDate, DateTime EndDate, string filename)
        {
            InitializeComponent();
            Set_form(StartDate, EndDate, filename);
            selectionManager = new SelectionManager(this.chart_CandleStick);
        }
        //Sets up data in newly created form
        private void Set_form(DateTime startDate, DateTime endDate, string filepath)
        {

           //Sets Up Modification Funtions
            var manager = new CandleStickManager();
            var proccessor = new FilePathProcessor();

            //Loads and Orginzies data loaded from CSV File and converts it into a list of SmartCandlesticks            
            loadedCandleSticksList = manager.LoadFromCsv(filepath);
            orderCandleSticksList = manager.OrderByDate(loadedCandleSticksList);
            filteredCandleStickList = manager.FilterByDateRange(orderCandleSticksList, startDate, endDate);


            //initialize information in Window form
            label_CurrentFilePath.Text = filepath;
            this.Text = proccessor.GetFileNameBeforeCsv(filepath);

            //initialize Charts
            Set_Charts(filteredCandleStickList, startDate, endDate);


        }
        private void button_Load_Click(object sender, EventArgs e)
        {
            //Shows dialog box so user can select filepath            
            openFileDialog_LoadFile.ShowDialog();
        }

        private void openFileDialog_LoadFile_FileOk(object sender, CancelEventArgs e)
        {

            //Create and sets filename varable
            var filepath = openFileDialog_LoadFile.FileName;


            //Create and set Date Varables
            DateTime startDate = dateTimePicker_StartDate.Value;
            DateTime endDate = dateTimePicker_EndDate.Value;


            //If mutiple files are selected create and set list of file names
            string[] fileNames = openFileDialog_LoadFile.FileNames;


            // Creates a new Form Window for each filename in array of filenames,
            // The first file in the list is not selected as it will update the current Form Window
            for (int i = 1; i < fileNames.Length; i++)
            {
                string fileName = fileNames[i];
                try
                {
                    //Creates and displays new Form Window
                    Form_InputAndDisplay Form_temp = new Form_InputAndDisplay(startDate, endDate, fileName);
                    Form_temp.Show();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing file {fileName}: {ex.Message}");
                }

            }


            //First or only file selected is proccessed
            //Sets Up Modification Funtions
            var manager = new CandleStickManager();
            var proccessor = new FilePathProcessor();

            //Loads and Orginzies data loaded from CSV File and converts it into a list of SmartCandlesticks            
            loadedCandleSticksList = manager.LoadFromCsv(filepath);
            orderCandleSticksList = manager.OrderByDate(loadedCandleSticksList);
            filteredCandleStickList = manager.FilterByDateRange(orderCandleSticksList, startDate, endDate);


            //initialize(First instance)/updates(any instance after) information in current Form Window
            label_CurrentFilePath.Text = filepath;
            this.Text = proccessor.GetFileNameBeforeCsv(filepath);

            //initialize(First instance)/updates(any instance after) 
            Set_Charts(filteredCandleStickList, startDate, endDate);
            
            //Clears Selection box and beauty Chart
            selectionManager.ClearSelectionBox();
            this.chart_Beauty.DataSource = selectionManager.GetBeautyList();
            this.chart_Beauty.DataBind();
            this.chart_Beauty.Update();

        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            
            
            //Create and set updated Date Varables
            DateTime startDate = dateTimePicker_StartDate.Value;
            DateTime endDate = dateTimePicker_EndDate.Value;

            //Sets Up Modification Funtions            
            var manager = new CandleStickManager();

            //Filters orderd candlestick list by updated Dates            
            filteredCandleStickList = manager.FilterByDateRange(orderCandleSticksList, startDate, endDate);


            //Update Chart clear Selected box
            Set_Charts(filteredCandleStickList, startDate, endDate);

            //Clears Selection box and beauty Chart
            selectionManager.ClearSelectionBox();
            this.chart_Beauty.DataSource = selectionManager.GetBeautyList();
            this.chart_Beauty.DataBind();
            this.chart_Beauty.Update();
            
        }

        private void Set_Charts(List<SmartCandlestick> filteredCandleList, DateTime startDate, DateTime endDate)
        {

            //Set CandleStick charts Variables          
            this.chart_CandleStick.DataSource = filteredCandleList;
            CandleStickManager.NormalizeCandleStick(filteredCandleList, chart_CandleStick, "ChartArea1");
            this.chart_CandleStick.DataBind();
            this.chart_CandleStick.Update();

        }

        private void Form_InputAndDisplay_Load(object sender, EventArgs e)
        {


        }

        private void chart_CandleStick_MouseDown(object sender, MouseEventArgs e)
        {
            //User clicks and holds on chart starting posistion is tracked and selection flag is turned on.
            if (e.Button == MouseButtons.Left)
            {

                selectionStart = e.Location;
                isSelecting = true;

            }
        }

        private void chart_CandleStick_MouseMove(object sender, MouseEventArgs e)
        {
            if (isSelecting)
            {
                //Tracks user movement to draw user Selection Rectangle.
                selectionRectangle = new Rectangle(
                    Math.Min(selectionStart.X, e.X),
                    Math.Min(selectionStart.Y, e.Y),
                    Math.Abs(selectionStart.X - e.X),
                    Math.Abs(selectionStart.Y - e.Y));
                chart_CandleStick.Invalidate(); // Forces the chart to redraw }

            }
        }
        private void chart_CandleStick_MouseUp(object sender, MouseEventArgs e)
        {

            //User release click, Final rectangle is Stored
            if (e.Button == MouseButtons.Left)
            {
                isSelecting = false;
                selectionManager.SetSelectionRectangle(selectionRectangle);                
                selectionManager.SelectCandlesticksInRectangle();               
                
            }           

            //Updates Chart_Beauty
            this.chart_Beauty.DataSource = selectionManager.GetBeautyList();
            this.chart_Beauty.DataBind();
            this.chart_Beauty.Update();


        }        

        private void chart_CandleStick_Paint(object sender, PaintEventArgs e)
        {
                        
            //Draws rectangle as user selected
            if (isSelecting) { 
                
                using (Pen pen = new Pen(Color.Red, 2)) { 
                    e.Graphics.DrawRectangle(pen, selectionRectangle);
                } 
            }
            //Draws Final Slection box and Fibonacci levels in the box
            selectionManager.DrawSelectionBox(e.Graphics);
           
        }
    }
}
