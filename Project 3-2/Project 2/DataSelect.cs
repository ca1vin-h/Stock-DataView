using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project_3
{
    public partial class DataSelect : Form
    {
        public DataSelect()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Called when user clicks "Choose Files" button. 
        /// Collects dates from dateTimePicker_StartDate and dateTimePicker_EndDate. 
        /// Loops through file names selected by user, sending file name and the dateTimePicker dates to a new Dataview.cs form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_LoadData_Click(object sender, EventArgs e)
        {
            //DateTime objects that will hold the start and end date selected by the user on this DataSelect.cs form
            DateTime startDate = dateTimePicker_StartDate.Value;
            DateTime endDate = dateTimePicker_EndDate.Value;

            //show the open file dialog
            openFileDialog1.ShowDialog();
            
            //iterate through each name in the list of names, returned by openfiledialog
            foreach(string filename in openFileDialog1.FileNames)
            {
                //create new dataview form
                DataView dv = new DataView(startDate, endDate, LoadCSV(filename));
                dv.Show();
            }
        }



        /// <summary>
        /// Converts CSV File containing stock data into a list of candlesticks
        /// </summary>
        /// <param name="csvFileLocation">A string containing CSV File location chosen by user</param>
        /// <returns>List of candlesticks containing the data from the CSV.</returns>
        private List<SmartCandlestick> LoadCSV(string csvFileLocation)
        {
            //Try-catch for catching bad CSV
            try
            {
                //Enumerate through all lines from chosen csv file, skipping the first line which contains the header. 
                //csvRowString_SkipsHeader contains a raw row from the csv file
                //data is a list of strings made by splitRow
                var enumerableCandlestick = 
                    
                    //Iterates through each line in chosen csv file, skipping the first line which contains the header.
                    from csvRowString_SkipsHeader in File.ReadAllLines(csvFileLocation).Skip(1)

                    //split each line into array containing each cell from the csv
                    let data = splitRow(csvRowString_SkipsHeader)

                    //SmartCandlestick creation
                    select new SmartCandlestick(data[0], 
                                                data[1], 
                                                data[2], 
                                                (decimal)Double.Parse(data[3]), 
                                                (decimal)Double.Parse(data[4]), 
                                                (decimal)Double.Parse(data[5]), 
                                                (decimal)Double.Parse(data[6]), 
                                                long.Parse(data[7]));

                //recognize multi pattern candlesticks
                List<SmartCandlestick> listOfCandlesticks = enumerableCandlestick.ToList();
                for (int i = 1; i < listOfCandlesticks.Count(); i++)
                {
                    if(i == listOfCandlesticks.Count() - 1)
                    {
                        //dont calculate peak and valley for last smartcandlestick
                        listOfCandlesticks[i].computeComplexPatterns(listOfCandlesticks[i - 1]);
                        break;
                    }
                    listOfCandlesticks[i].computeComplexPatterns(listOfCandlesticks[i-1], listOfCandlesticks[i+1]);
                }

                //returns ienumerable<smartcandlestick> as list<smartcandlestick>
                return listOfCandlesticks;
            }


            //Will fire off if the user chose an invalid file in openfiledialog
            catch (System.ArgumentNullException)
            {
                MessageBox.Show("Invalid File chosen!\n" +
                                "Please choose a CSV File whose name matches the following format:\n" +
                                "Ticker-Period.csv\n" +
                                "And contains data that matches the following format:\n" +
                                "Ticker (string), Period (string), Date (string), Open (double), High (double), Low (double), Close (double), Volume (double)\n\n" +
                                "NOTE: \n" +
                                "Ticker: Stock ticker EX: AAPL\n" +
                                "Period: Day, Week, or Month\n" +
                                "Date: MMM dd, yyyy EX: \"Oct 20, 2023\"", "ERROR: Invalid CSV");
                return null;
            }


        }


        /// <summary> 
        /// Splits a row of csv data into columns
        /// </summary>
        /// <param name="data">A string containing a row of csv data delimited by quotes and commas</param>
        /// <returns>An array of strings, each containing a value parsed from the csv row</returns>
        private string[] splitRow(string data)
        {
            // array that will split csv elements from row into different indices.
            string[] splitRowList = new string[9];
            splitRowList[0] = "";
            int splitRowListIndex = 0;

            //flag for determining when an element is quoted
            bool isQuoted = false;

            //loop that reads through each character in row string
            for (int i = 0; i < data.Length; i++)
            {
                //set !flag when quote is found
                if (data[i] == '\"')
                {
                    isQuoted = !isQuoted;
                    continue;
                }
                //increment splitRowListIndex when unquoted comma found (means to move on to next element in csv row)
                if (data[i] == ',' && !isQuoted)
                {
                    splitRowListIndex++;
                    splitRowList[splitRowListIndex] = "";// set element in array to non null value
                    continue;
                }
                splitRowList[splitRowListIndex] += data[i]; //add character to splitRowList because it isn't a comma or quote

            }
            return splitRowList;
        }
    }
}
