namespace Project3
{
    partial class Form_InputAndDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_Load = new System.Windows.Forms.Button();
            this.button_Update = new System.Windows.Forms.Button();
            this.dateTimePicker_StartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_EndDate = new System.Windows.Forms.DateTimePicker();
            this.label_StartDate = new System.Windows.Forms.Label();
            this.label_EndDate = new System.Windows.Forms.Label();
            this.label_FilePath = new System.Windows.Forms.Label();
            this.label_CurrentFilePath = new System.Windows.Forms.Label();
            this.chart_CandleStick = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.openFileDialog_LoadFile = new System.Windows.Forms.OpenFileDialog();
            this.chart_Beauty = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox_Instruction = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart_CandleStick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Beauty)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Load
            // 
            this.button_Load.Location = new System.Drawing.Point(839, 734);
            this.button_Load.Margin = new System.Windows.Forms.Padding(2);
            this.button_Load.Name = "button_Load";
            this.button_Load.Size = new System.Drawing.Size(107, 26);
            this.button_Load.TabIndex = 0;
            this.button_Load.Text = "Load";
            this.button_Load.UseVisualStyleBackColor = true;
            this.button_Load.Click += new System.EventHandler(this.button_Load_Click);
            // 
            // button_Update
            // 
            this.button_Update.Location = new System.Drawing.Point(839, 765);
            this.button_Update.Margin = new System.Windows.Forms.Padding(2);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(107, 26);
            this.button_Update.TabIndex = 1;
            this.button_Update.Text = "Update";
            this.button_Update.UseVisualStyleBackColor = true;
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // dateTimePicker_StartDate
            // 
            this.dateTimePicker_StartDate.Location = new System.Drawing.Point(66, 732);
            this.dateTimePicker_StartDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_StartDate.Name = "dateTimePicker_StartDate";
            this.dateTimePicker_StartDate.Size = new System.Drawing.Size(248, 20);
            this.dateTimePicker_StartDate.TabIndex = 2;
            this.dateTimePicker_StartDate.Value = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_EndDate
            // 
            this.dateTimePicker_EndDate.Location = new System.Drawing.Point(587, 734);
            this.dateTimePicker_EndDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_EndDate.Name = "dateTimePicker_EndDate";
            this.dateTimePicker_EndDate.Size = new System.Drawing.Size(248, 20);
            this.dateTimePicker_EndDate.TabIndex = 3;
            this.dateTimePicker_EndDate.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // label_StartDate
            // 
            this.label_StartDate.AutoSize = true;
            this.label_StartDate.Location = new System.Drawing.Point(11, 734);
            this.label_StartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_StartDate.Name = "label_StartDate";
            this.label_StartDate.Size = new System.Drawing.Size(55, 13);
            this.label_StartDate.TabIndex = 4;
            this.label_StartDate.Text = "Start Date";
            // 
            // label_EndDate
            // 
            this.label_EndDate.AutoSize = true;
            this.label_EndDate.Location = new System.Drawing.Point(537, 734);
            this.label_EndDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_EndDate.Name = "label_EndDate";
            this.label_EndDate.Size = new System.Drawing.Size(49, 13);
            this.label_EndDate.TabIndex = 5;
            this.label_EndDate.Text = "EndDate";
            // 
            // label_FilePath
            // 
            this.label_FilePath.AutoSize = true;
            this.label_FilePath.Location = new System.Drawing.Point(12, 765);
            this.label_FilePath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_FilePath.Name = "label_FilePath";
            this.label_FilePath.Size = new System.Drawing.Size(54, 13);
            this.label_FilePath.TabIndex = 6;
            this.label_FilePath.Text = "File Path: ";
            // 
            // label_CurrentFilePath
            // 
            this.label_CurrentFilePath.AutoSize = true;
            this.label_CurrentFilePath.Location = new System.Drawing.Point(64, 765);
            this.label_CurrentFilePath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_CurrentFilePath.Name = "label_CurrentFilePath";
            this.label_CurrentFilePath.Size = new System.Drawing.Size(13, 13);
            this.label_CurrentFilePath.TabIndex = 7;
            this.label_CurrentFilePath.Text = "_";
            // 
            // chart_CandleStick
            // 
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisY.IsStartedFromZero = false;
            chartArea3.AxisY.MajorGrid.Enabled = false;
            chartArea3.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.TileFlipX;
            chartArea3.Name = "ChartArea1";
            this.chart_CandleStick.ChartAreas.Add(chartArea3);
            this.chart_CandleStick.Location = new System.Drawing.Point(15, 36);
            this.chart_CandleStick.Margin = new System.Windows.Forms.Padding(2);
            this.chart_CandleStick.Name = "chart_CandleStick";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series3.CustomProperties = "PriceDownColor=Red, PriceUpColor=Green";
            series3.Name = "Series1";
            series3.XValueMember = "Date";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series3.YValueMembers = "High,Low,Open,Close";
            series3.YValuesPerPoint = 4;
            this.chart_CandleStick.Series.Add(series3);
            this.chart_CandleStick.Size = new System.Drawing.Size(934, 484);
            this.chart_CandleStick.TabIndex = 9;
            this.chart_CandleStick.Text = "chart2";
            this.chart_CandleStick.Paint += new System.Windows.Forms.PaintEventHandler(this.chart_CandleStick_Paint);
            this.chart_CandleStick.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart_CandleStick_MouseDown);
            this.chart_CandleStick.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart_CandleStick_MouseMove);
            this.chart_CandleStick.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chart_CandleStick_MouseUp);
            // 
            // openFileDialog_LoadFile
            // 
            this.openFileDialog_LoadFile.FileName = "Stock Data";
            this.openFileDialog_LoadFile.Filter = "All Files|*-*.csv|Day|*-Day.csv|Month|*-Month.csv|Year|*-Year.csv";
            this.openFileDialog_LoadFile.Multiselect = true;
            this.openFileDialog_LoadFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_LoadFile_FileOk);
            // 
            // chart_Beauty
            // 
            chartArea4.AxisX.Interval = 5D;
            chartArea4.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea4.Name = "ChartArea1";
            this.chart_Beauty.ChartAreas.Add(chartArea4);
            this.chart_Beauty.Location = new System.Drawing.Point(15, 525);
            this.chart_Beauty.Name = "chart_Beauty";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Name = "Series1";
            series4.XValueMember = "Price";
            series4.YValueMembers = "BeautyValue";
            this.chart_Beauty.Series.Add(series4);
            this.chart_Beauty.Size = new System.Drawing.Size(934, 185);
            this.chart_Beauty.TabIndex = 10;
            this.chart_Beauty.Text = "chart1";
            // 
            // textBox_Instruction
            // 
            this.textBox_Instruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Instruction.Location = new System.Drawing.Point(15, 11);
            this.textBox_Instruction.Name = "textBox_Instruction";
            this.textBox_Instruction.Size = new System.Drawing.Size(931, 26);
            this.textBox_Instruction.TabIndex = 11;
            this.textBox_Instruction.Text = "Click and Drag to Select Wave you Wish to Analyze.";
            // 
            // Form_InputAndDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 805);
            this.Controls.Add(this.textBox_Instruction);
            this.Controls.Add(this.chart_Beauty);
            this.Controls.Add(this.chart_CandleStick);
            this.Controls.Add(this.label_CurrentFilePath);
            this.Controls.Add(this.label_FilePath);
            this.Controls.Add(this.label_EndDate);
            this.Controls.Add(this.label_StartDate);
            this.Controls.Add(this.dateTimePicker_EndDate);
            this.Controls.Add(this.dateTimePicker_StartDate);
            this.Controls.Add(this.button_Update);
            this.Controls.Add(this.button_Load);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_InputAndDisplay";
            this.Text = "No CSV File Selected";
            this.Load += new System.EventHandler(this.Form_InputAndDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_CandleStick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Beauty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Load;
        private System.Windows.Forms.Button button_Update;
        private System.Windows.Forms.DateTimePicker dateTimePicker_StartDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_EndDate;
        private System.Windows.Forms.Label label_StartDate;
        private System.Windows.Forms.Label label_EndDate;
        private System.Windows.Forms.Label label_FilePath;
        private System.Windows.Forms.Label label_CurrentFilePath;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_CandleStick;
        private System.Windows.Forms.OpenFileDialog openFileDialog_LoadFile;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Beauty;
        private System.Windows.Forms.TextBox textBox_Instruction;
    }
}

