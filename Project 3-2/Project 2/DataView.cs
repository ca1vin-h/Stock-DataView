using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project_3
{
    public partial class DataView : Form
    {
        //Smart Candlestick List
        List<SmartCandlestick> listOfSmartCandlesticks = new List<SmartCandlestick>();

        //Selection of Smart Candlestick List
        List<SmartCandlestick> selectionOfSmartCandlesticks = new List<SmartCandlestick>();

        List<Recognizer> listOfRecognizers = new List<Recognizer>(100);
        /// <summary>
        /// Dataview Form
        /// </summary>
        /// <param name="startDate">DateTime start date</param>
        /// <param name="endDate">DateTime end date</param>
        /// <param name="listOfCandleSticks">List<Candlestick> list of candlesticks</Candlestick></param>
        public DataView(DateTime startDate, DateTime endDate, List<SmartCandlestick> loscs)
        {
            InitializeComponent();
            //set window title
            Text = loscs[1].Ticker + " " + loscs[1].Period;

            //set chart title
            chart_PriceVolume.Titles.Add(loscs[1].Ticker + " " + loscs[1].Period);

            //add smartcandlesticks to listofsmartcandlesticks
            foreach (SmartCandlestick l in loscs)
            {
                listOfSmartCandlesticks.Add(l);
            }

            //set datetimepickers to datetime selected in Dataselect.cs
            dateTimePicker_StartDate.Value = startDate;
            dateTimePicker_EndDate.Value = endDate;

            //
            chart_PriceVolume.Series["series_Volume"]["ShowOpenClose"] = "Both";

            //initial data selected by user
            setChartData(smartCandlestickSelection());

            //create list of recognizers
            listOfRecognizers.Add(new DojiRecognizer());
            listOfRecognizers.Add(new MarubuzoRecognizer());
            listOfRecognizers.Add(new BullishRecognizer());
            listOfRecognizers.Add(new NeutralRecognizer());
            listOfRecognizers.Add(new BearishRecognizer());
            listOfRecognizers.Add(new DragonFlyDojiRecognizer());
            listOfRecognizers.Add(new GravestoneDojiRecognizer());
            listOfRecognizers.Add(new HammerRecognizer());
            listOfRecognizers.Add(new InvertedHammerRecognizer());
            listOfRecognizers.Add(new EngulfingPatternRecognizer());
            listOfRecognizers.Add(new BearishEngulfingPatternRecognizer());
            listOfRecognizers.Add(new BullishEngulfingPatternRecognizer());
            listOfRecognizers.Add(new EngulfingHaramiRecognizer());
            listOfRecognizers.Add(new BullishEngulfingHaramiRecognizer());
            listOfRecognizers.Add(new BearishEngulfingHaramiRecognizer());
            listOfRecognizers.Add(new PeakRecognizer());
            listOfRecognizers.Add(new ValleyRecognizer());

            //add recognizers to combobox
            foreach (Recognizer r in listOfRecognizers)
            {
                comboBox_selectedPattern.Items.Add(r.Name);
            }



            //manually set window size
            this.Size = new System.Drawing.Size(2196 / 2, (int)((double)1256 / 1.9));
        }


        /// <summary>
        /// Called when user selects "Update" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_UpdateChart_Click(object sender, EventArgs e)
        {
            chart_PriceVolume.Annotations.Clear();
            setChartData(smartCandlestickSelection());
            Refresh();
        }

        /// <summary>
        /// Sets chart data, using the date selection set by user to create a smaller list of smartcandlesticks to be displayed
        /// </summary>
        /// <param name="chosen_Candlesticks_Reversed">Reversed(correct order for chart) selection of candlesticks</param>
        private void setChartData(List<SmartCandlestick> chosen_Candlesticks_Reversed)
        {
            chart_PriceVolume.DataSource = chosen_Candlesticks_Reversed;
            chart_PriceVolume.DataBind();
        }


        /// <summary>
        /// Returns a selection of smartcandlestick objects between start and end date. Uses the dates chosen in the two datetimepickers and 
        /// </summary>
        /// <returns>returns selection of smartcandlesticks as list of smartcandlestick</returns>
        private List<SmartCandlestick> smartCandlestickSelection()
        {
            //List created to hold stock data chosen by user
            List<SmartCandlestick> chosen_stockData = new List<SmartCandlestick>();

            //Startflag: boolean that is set to true when the start of the user selected dates are reached
            bool startFlag = false;

            //Endflag: boolean that is set to true when the end of the user selected dates are reached
            bool endFlag = false;


            //loop through each candlestick in csv file backwards, using the end date to determine when to start capturing data, and the start date to determine when to stop capturing data.
            //NOTE: The data has not been reversed
            DateTime startDate = getStartDate();
            DateTime endDate = getEndDate();

            foreach (SmartCandlestick cs in listOfSmartCandlesticks)
            {
                if (cs == null)
                {
                    continue;
                }
                //set end flag if loop is at end date
                if (cs.smartDate.Equals(endDate))
                {
                    endFlag = true;
                }
                //add candlestick to chosen data as it falls between start and end date
                if (endFlag == true && startFlag == false)
                {
                    chosen_stockData.Add(cs);
                }
                //set start flag if loop is at start date
                if (cs.smartDate.Equals(startDate))
                {
                    startFlag = true;
                }
            }


            //If there is nothing found in the list, show the user a message box that nothing was found
            if (!chosen_stockData.Any())
            {
                MessageBox.Show("No Data Selected, Please check start and end dates.");
            }


            //reverse data so it shows up on chart in correct order
            List<SmartCandlestick> chosen_stockData_reversed = new List<SmartCandlestick>();
            for (int i = chosen_stockData.Count() - 1; i >= 0; i--)
            {
                chosen_stockData_reversed.Add(chosen_stockData[i]);
            }
            selectionOfSmartCandlesticks.Clear();
            foreach(SmartCandlestick cs in chosen_stockData_reversed)
            {
                selectionOfSmartCandlesticks.Add(cs);
            }
            return chosen_stockData_reversed;
        }



        /// <summary>
        /// Returns closest future start date in stock data to date specified by user
        /// </summary>
        /// <returns>Returns DateTime Object containing the first date after user suggested start date. If the user selected a date present on the csv then that date will be returned.</returns>
        private DateTime getStartDate()
        {
            DateTime actualStartDate = DateTime.UtcNow;
            foreach (SmartCandlestick scs in listOfSmartCandlesticks)
            {
                //compare dates, if the suggested date is less than or equal to a date found in the candlestick list, then set that to the actual start date
                if (dateTimePicker_StartDate.Value <= scs.smartDate)
                {
                    actualStartDate = scs.smartDate;
                }
            }
            return actualStartDate;
        }


        /// <summary>
        /// Returns closest past end date in stock data to date specified by user
        /// </summary>
        /// <returns>Returns DateTime Object containing last date before user suggested end date. If the user selected a date present on the csv then that date will be returned.</returns>
        private DateTime getEndDate()
        {
            DateTime actualEndDate = DateTime.UtcNow;
            //iterate backwards through array
            for (int i = listOfSmartCandlesticks.Count() - 1; i >= 0; i--)
            {
                //compare dates, if the suggested date is greater than or equal to a date found in the candlestick list, then set that to the actual end date
                if (dateTimePicker_EndDate.Value >= listOfSmartCandlesticks[i].smartDate)
                {
                    actualEndDate = listOfSmartCandlesticks[i].smartDate;
                }
            }
            return actualEndDate;
        }


        /// <summary>
        /// Function that adds the annotations to the chart
        /// </summary>
        /// <param name="point">location of candlestick</param>
        /// <param name="text">text to be annotated to candlestick</param>
        private void AddAnnotation(DataPoint point, string text)
        {
            // Create annotation
            RectangleAnnotation rectangleAnnotation = new RectangleAnnotation();
            rectangleAnnotation.Text = text;
            rectangleAnnotation.AnchorDataPoint = point;

            // Add the annotation to the chart
            chart_PriceVolume.Annotations.Add(rectangleAnnotation);
        }

        /// <summary>
        /// adds arrowannotations to chart, does not work
        /// </summary>
        /// <param name="point">datapoint made from index</param>
        private void AddArrowAnnotation(DataPoint point)
        {
            ArrowAnnotation arrowAnnotation = new ArrowAnnotation();
            arrowAnnotation.AnchorDataPoint = point;
            arrowAnnotation.LineColor = System.Drawing.Color.Red;
            arrowAnnotation.Tag = "test";
            arrowAnnotation.ArrowSize = 3;
            chart_PriceVolume.Annotations.Add(arrowAnnotation);
            chart_PriceVolume.Annotations.Append(arrowAnnotation);
        }

        /// <summary>
        /// Function called when user selects a pattern from the combobox.
        /// </summary>
        private void comboBox_selectedPattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            //loop through pattern indice for selected pattern
            foreach (int index in listOfRecognizers[comboBox_selectedPattern.SelectedIndex].recognizePatternIndices(selectionOfSmartCandlesticks))
            {
                AddAnnotation(chart_PriceVolume.Series["series_Price"].Points[index], listOfRecognizers[comboBox_selectedPattern.SelectedIndex].Name);

                //AddArrowAnnotation(chart_PriceVolume.Series["series_Price"].Points[index]);
            }
        }


        /// <summary>
        /// button called when user clicks "clear annotations" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_clearAnnotations_Click(object sender, EventArgs e)
        {
            chart_PriceVolume.Annotations.Clear();
        }
    }

    
}
