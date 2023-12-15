using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_3
{
    /// <summary>
    /// Base Recognizer Class
    /// </summary>
    abstract class Recognizer
    {
        
        public List<int> recognizePatternIndices(List<SmartCandlestick> listOfSmartCandlesticks)
        {
            //SmartCandlestick[] arrayOfSmartCandlesticks = listOfSmartCandlesticks.ToArray();
            List<int> result = new List<int>(listOfSmartCandlesticks.Count);
            for (int i = 0; i < listOfSmartCandlesticks.Count; i++)
            {
                SmartCandlestick scs = listOfSmartCandlesticks[i];
                if (recognizePattern(scs)) 
                { 
                    result.Add(i); 
                }

            }
            return result;
        }
        public abstract bool recognizePattern(SmartCandlestick scs);
        public string Name { get; set; }

    }


    /// <summary>
    /// derived classes
    /// </summary>
    internal class DojiRecognizer : Recognizer
    {
        public DojiRecognizer()
        {
            Name = "Doji";
        }
        public override bool recognizePattern(SmartCandlestick scs)
        {
            return scs.isDoji;
        }
        
    }

    internal class MarubuzoRecognizer : Recognizer
    {
        public MarubuzoRecognizer()
        {
            Name = "Marubuzo";
        }
        public override bool recognizePattern(SmartCandlestick scs)
        {
            return scs.isMarubozu;
        }
    }


    internal class BullishRecognizer : Recognizer
    {
        public BullishRecognizer()
        {
            Name = "Bullish";
        }
        public override bool recognizePattern(SmartCandlestick scs)
        {
            return scs.isBullish;
        }
    }

    internal class NeutralRecognizer : Recognizer
    {
        public NeutralRecognizer()
        {
            Name = "Neutral";
        }
        public override bool recognizePattern(SmartCandlestick scs)
        {
            return scs.isNeutral;
        }
    }

    internal class BearishRecognizer : Recognizer
    {
        public BearishRecognizer()
        {
            Name = "Bearish";
        }
        public override bool recognizePattern(SmartCandlestick scs)
        {
            return scs.isBearish;
        }
    }

    internal class DragonFlyDojiRecognizer : Recognizer
    {
        public DragonFlyDojiRecognizer()
        {
            Name = "Dragonfly Doji";
        }
        public override bool recognizePattern(SmartCandlestick scs)
        {
            return scs.isDragonFlyDoji;
        }
    }

    internal class GravestoneDojiRecognizer : Recognizer
    {
        public GravestoneDojiRecognizer()
        {
            Name = "Gravestone Doji";
        }
        public override bool recognizePattern(SmartCandlestick scs)
        {
            return scs.isGravestoneDoji;
        }
    }

    internal class HammerRecognizer : Recognizer
    {
        public HammerRecognizer()
        {
            Name = "Hammer";
        }
        public override bool recognizePattern(SmartCandlestick scs)
        {
            return scs.isHammer;
        }
    }

    internal class InvertedHammerRecognizer : Recognizer
    {
        public InvertedHammerRecognizer()
        {
            Name = "Inverted Hammer";
        }
        public override bool recognizePattern(SmartCandlestick scs)
        {
            return scs.isInvertedHammer;
        }
    }

    internal class EngulfingPatternRecognizer : Recognizer
    {
        public EngulfingPatternRecognizer()
        {
            Name = "Engulfing Pattern";
        }
        public override bool recognizePattern(SmartCandlestick scs)
        {
            return scs.isEngulfingPattern;
        }
    }

    internal class BearishEngulfingPatternRecognizer : Recognizer
    {
        public BearishEngulfingPatternRecognizer()
        {
            Name = "Bearish Engulfing Pattern";
        }
        public override bool recognizePattern(SmartCandlestick scs)
        {
            return scs.isBearishEngulfingPattern;
        }
    }

    internal class BullishEngulfingPatternRecognizer : Recognizer
    {
        public BullishEngulfingPatternRecognizer()
        {
            Name = "Bullish Engulfing Pattern";
        }
        public override bool recognizePattern(SmartCandlestick scs)
        {
            return scs.isBullishEngulfingPattern;
        }
    }

    internal class EngulfingHaramiRecognizer : Recognizer
    {
        public EngulfingHaramiRecognizer()
        {
            Name = "Harami";
        }
        public override bool recognizePattern(SmartCandlestick scs)
        {
            return scs.isEngulfingHarami;
        }
    }

    internal class BullishEngulfingHaramiRecognizer : Recognizer
    {
        public BullishEngulfingHaramiRecognizer()
        {
            Name = "Bullish Harami";
        }
        public override bool recognizePattern(SmartCandlestick scs)
        {
            return scs.isBullishEngulfingHarami;
        }
    }

    internal class BearishEngulfingHaramiRecognizer : Recognizer
    {
        public BearishEngulfingHaramiRecognizer()
        {
            Name = "Bearish Harami";
        }
        public override bool recognizePattern(SmartCandlestick scs)
        {
            return scs.isBearishEngulfingHarami;
        }
    }

    internal class PeakRecognizer : Recognizer
    {
        public PeakRecognizer()
        {
            Name = "Peak";
        }
        public override bool recognizePattern(SmartCandlestick scs)
        {
            return scs.isPeak;
        }
    }

    internal class ValleyRecognizer : Recognizer
    {
        public ValleyRecognizer()
        {
            Name = "Valley";
        }
        public override bool recognizePattern(SmartCandlestick scs)
        {
            return scs.isValley;
        }
    }
}
