namespace Project_3
{
    partial class DataView
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_PriceVolume = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimePicker_StartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_EndDate = new System.Windows.Forms.DateTimePicker();
            this.button_UpdateChart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_selectedPattern = new System.Windows.Forms.ComboBox();
            this.button_clearAnnotations = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart_PriceVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_PriceVolume
            // 
            chartArea1.AxisX.Title = "Date";
            chartArea1.AxisY.Title = "Price";
            chartArea1.Name = "ChartArea_Price";
            chartArea2.AlignWithChartArea = "ChartArea_Price";
            chartArea2.AxisX.Title = "Date";
            chartArea2.AxisY.Title = "Volume";
            chartArea2.Name = "ChartArea_Volume";
            this.chart_PriceVolume.ChartAreas.Add(chartArea1);
            this.chart_PriceVolume.ChartAreas.Add(chartArea2);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart_PriceVolume.Legends.Add(legend1);
            this.chart_PriceVolume.Location = new System.Drawing.Point(0, 0);
            this.chart_PriceVolume.Margin = new System.Windows.Forms.Padding(6);
            this.chart_PriceVolume.Name = "chart_PriceVolume";
            series1.ChartArea = "ChartArea_Price";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=green";
            series1.Legend = "Legend1";
            series1.Name = "series_Price";
            series1.XValueMember = "Date";
            series1.YValueMembers = "High, Low, Open, Close";
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "ChartArea_Volume";
            series2.Legend = "Legend1";
            series2.Name = "series_Volume";
            series2.XValueMember = "Date";
            series2.YValueMembers = "Volume";
            this.chart_PriceVolume.Series.Add(series1);
            this.chart_PriceVolume.Series.Add(series2);
            this.chart_PriceVolume.Size = new System.Drawing.Size(2170, 1067);
            this.chart_PriceVolume.TabIndex = 0;
            this.chart_PriceVolume.Text = "chart1";
            // 
            // dateTimePicker_StartDate
            // 
            this.dateTimePicker_StartDate.Location = new System.Drawing.Point(28, 1127);
            this.dateTimePicker_StartDate.Margin = new System.Windows.Forms.Padding(6);
            this.dateTimePicker_StartDate.Name = "dateTimePicker_StartDate";
            this.dateTimePicker_StartDate.Size = new System.Drawing.Size(396, 31);
            this.dateTimePicker_StartDate.TabIndex = 1;
            // 
            // dateTimePicker_EndDate
            // 
            this.dateTimePicker_EndDate.Location = new System.Drawing.Point(712, 1127);
            this.dateTimePicker_EndDate.Margin = new System.Windows.Forms.Padding(6);
            this.dateTimePicker_EndDate.Name = "dateTimePicker_EndDate";
            this.dateTimePicker_EndDate.Size = new System.Drawing.Size(396, 31);
            this.dateTimePicker_EndDate.TabIndex = 2;
            // 
            // button_UpdateChart
            // 
            this.button_UpdateChart.Location = new System.Drawing.Point(502, 1123);
            this.button_UpdateChart.Margin = new System.Windows.Forms.Padding(6);
            this.button_UpdateChart.Name = "button_UpdateChart";
            this.button_UpdateChart.Size = new System.Drawing.Size(150, 44);
            this.button_UpdateChart.TabIndex = 3;
            this.button_UpdateChart.Text = "Update";
            this.button_UpdateChart.UseVisualStyleBackColor = true;
            this.button_UpdateChart.Click += new System.EventHandler(this.button_UpdateChart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 1090);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Start Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(510, 1090);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Update Chart:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(820, 1090);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Select End Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1177, 1119);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(293, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Select a pattern to recognize:";
            // 
            // comboBox_selectedPattern
            // 
            this.comboBox_selectedPattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_selectedPattern.FormattingEnabled = true;
            this.comboBox_selectedPattern.Location = new System.Drawing.Point(1481, 1113);
            this.comboBox_selectedPattern.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox_selectedPattern.Name = "comboBox_selectedPattern";
            this.comboBox_selectedPattern.Size = new System.Drawing.Size(245, 33);
            this.comboBox_selectedPattern.TabIndex = 8;
            this.comboBox_selectedPattern.SelectedIndexChanged += new System.EventHandler(this.comboBox_selectedPattern_SelectedIndexChanged);
            // 
            // button_clearAnnotations
            // 
            this.button_clearAnnotations.Location = new System.Drawing.Point(1812, 1110);
            this.button_clearAnnotations.Name = "button_clearAnnotations";
            this.button_clearAnnotations.Size = new System.Drawing.Size(213, 43);
            this.button_clearAnnotations.TabIndex = 9;
            this.button_clearAnnotations.Text = "Clear Annotations";
            this.button_clearAnnotations.UseVisualStyleBackColor = true;
            this.button_clearAnnotations.Click += new System.EventHandler(this.button_clearAnnotations_Click);
            // 
            // DataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2170, 1185);
            this.Controls.Add(this.button_clearAnnotations);
            this.Controls.Add(this.comboBox_selectedPattern);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_UpdateChart);
            this.Controls.Add(this.dateTimePicker_EndDate);
            this.Controls.Add(this.dateTimePicker_StartDate);
            this.Controls.Add(this.chart_PriceVolume);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "DataView";
            this.Text = "DataView";
            ((System.ComponentModel.ISupportInitialize)(this.chart_PriceVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_PriceVolume;
        private System.Windows.Forms.DateTimePicker dateTimePicker_StartDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_EndDate;
        private System.Windows.Forms.Button button_UpdateChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_selectedPattern;
        private System.Windows.Forms.Button button_clearAnnotations;
    }
}