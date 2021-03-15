using Models.ConverterModels.Common.Interface;

using System;
using System.Collections.Generic;

namespace Models.ConverterModels.Common
{
    public class LengthConstantsWithReferenceCentimeter : IContainerOfSystemConstants
    {
        public Dictionary<string, decimal> Constants { get; set; }

        public LengthConstantsWithReferenceCentimeter()
        {
            Constants = new Dictionary<string, decimal>()
            {
                { "Millimeter", Decimal.Parse("0,1")},
                { "Centimeter", 1 },
                { "Decimeter",  10 },
                { "Metre",      100 },
                { "Kilometer",  100000 },
                { "Ft",         Decimal.Parse("30,48")},
                { "Inch",       Decimal.Parse("2,54")},
                { "Yard",       Decimal.Parse("91,44")},
                { "Mile",       Decimal.Parse("160934,4")}
            };
        }
    }
}
