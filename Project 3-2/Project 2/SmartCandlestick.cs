using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_3
{
    public class SmartCandlestick : Candlestick
    {
        //smart properties
        public DateTime smartDate;
        public decimal range;
        public decimal bodyRange;
        public decimal topPrice;
        public decimal bottomPrice;
        public decimal upperTail;
        public decimal lowerTail;


        //single candlestick patterns
        public bool isDoji;
        public bool isBullish;
        public bool isBearish;
        public bool isNeutral;

        public bool isMarubozu;
        public bool isDragonFlyDoji;
        public bool isGravestoneDoji;
        public bool isHammer;
        public bool isInvertedHammer;

        //multiple candlestick patterns
        public bool isEngulfingPattern;
        public bool isBullishEngulfingPattern;
        public bool isBearishEngulfingPattern;

        public bool isEngulfingHarami;
        public bool isBullishEngulfingHarami;
        public bool isBearishEngulfingHarami;

        public bool isPeak;
        public bool isValley;


        /// <summary>
        /// Default Constructor, unused in this project
        /// </summary>
        public SmartCandlestick()
        {
            computeSmartProperties();
            computePatterns();
        }

        /// <summary>
        /// SmartCandlestick Constructor that sets all of the candlestick and smartcandlestick properties
        /// </summary>
        /// <param name="ticker">AMD, AAPL, IBM</param>
        /// <param name="period">Day, Week, Month</param>
        /// <param name="date">Date in MMM dd yyyy "Jan 1, 2022" or "Aug 31, 2023"</param>
        /// <param name="open"></param>
        /// <param name="high"></param>
        /// <param name="low"></param>
        /// <param name="close"></param>
        /// <param name="volume"></param>
        public SmartCandlestick(string Ticker, string Period, string Date, decimal Open, decimal High, decimal Low, decimal Close, long Volume)
        {
            this.Ticker = Ticker;
            this.Period = Period;
            this.Date = Date;
            this.Open = Open;
            this.High = High;
            this.Low = Low;
            this.Close = Close;
            this.Volume = Volume;
            computeSmartProperties();
            computePatterns();
        }


        /// <summary>
        /// Higher level properties used to compute patterns
        /// </summary>
        public void computeSmartProperties()
        {
            range = High - Low;
            topPrice = Math.Max(Open, Close);
            bottomPrice = Math.Min(Open, Close);
            upperTail = High - topPrice;
            lowerTail = bottomPrice - Low;
            bodyRange = topPrice - bottomPrice;
            smartDate = dateTimeConverter(Date);

        }

        /// <summary>
        /// Compute single candlestick patterns
        /// </summary>
        public void computePatterns()
        {
            isDoji = bodyRange <= (Decimal) 0.03 * Open;
            isMarubozu = bodyRange * (Decimal) 1.03 >= range;
            isBullish = Close > Open;
            isNeutral = Close == Open;
            isBearish = Close < Open;
            isDragonFlyDoji = isDoji && upperTail <= (Decimal)0.03 * Open && lowerTail >= (Decimal).90*range;
            isGravestoneDoji = isDoji && lowerTail <= (Decimal)0.03 * Open && upperTail >= (Decimal).90 * range;
            isHammer = lowerTail >= 3 * (upperTail + bodyRange);
            isInvertedHammer = upperTail >= 3 * (lowerTail + bodyRange);
        }






        /// <summary>
        /// Converts date in MMM dd yyyy format to DateTime object. Example: "Jan 1, 2022" or "Aug 31, 2023"
        /// </summary>
        /// <param name="dateText">String containing a date in MMM dd yyyy format</param>
        /// <returns>DateTime object set to date provided in dateText string</returns>
        public DateTime dateTimeConverter(string dateText)
        {
            //remove all commas in string
            dateText = dateText.Replace(",", "");

            //split string where there are spaces
            string[] dateTextSplit = dateText.Split(' ');

            /* array of integers necessary to create datetime object
             * 0: year
             * 1: day
             * 2: month
             */
            int[] dateIntegers = { 0, 0, 0 };
            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            dateIntegers[0] = Int32.Parse(dateTextSplit[2]);
            dateIntegers[2] = Int32.Parse(dateTextSplit[1]);

            //convert abbreviated date to number
            for (int i = 0; i < 12; i++)
            {
                if (dateTextSplit[0].Equals(months[i]))
                {
                    dateIntegers[1] = i + 1;
                }
            }

            //create and return datetime object
            return new DateTime(dateIntegers[0], dateIntegers[1], dateIntegers[2], 0, 0, 0);
        }


        /// <summary>
        /// function that computes all of the multiple candlestick patterns
        /// </summary>
        /// <param name="previous">smartcandlestick that comes before selected candlestick</param>
        /// <param name="next">smartcandlestick that comes after selected candlestick</param>
        public void computeComplexPatterns(SmartCandlestick previous, SmartCandlestick next)
        {
            isPeak = High > previous.High && High > next.High;
            isValley = Low < previous.Low && Low < next.Low;
            computeComplexPatterns(previous);
        }


        /// <summary>
        /// function that computes candlestick patterns which do not require future candlestick (valley and peak)
        /// </summary>
        /// <param name="previous">smartcandlestick that comes before selected candlestick</param>
        public void computeComplexPatterns(SmartCandlestick previous)
        {
            isEngulfingPattern        = bottomPrice < previous.bottomPrice
                                        && Low < previous.Low
                                        && topPrice > previous.topPrice
                                        && High > previous.High;

            isBullishEngulfingPattern = isEngulfingPattern
                                        && previous.isBearish
                                        && isBullish;

            isBearishEngulfingPattern = isEngulfingPattern
                                        && previous.isBullish
                                        && isBearish;

            isEngulfingHarami         = High < previous.topPrice
                                        && Low > previous.bottomPrice;

            isBullishEngulfingHarami  = isEngulfingHarami
                                        && previous.isBearish
                                        && isBullish
                                        && Low > (previous.bottomPrice * (Decimal)1.05);

            isBearishEngulfingHarami  = isEngulfingHarami
                                        && previous.isBullish
                                        && isBearish
                                        && High < (previous.topPrice * (Decimal)1.05);
        }



    }
}
