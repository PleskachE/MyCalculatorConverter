using Models.ConverterModels.Common.Interface;

using System;
using System.Collections.Generic;

namespace Models.ConverterModels.Common
{
    public class WeightsConstantsWithReferenceKilogram : IContainerOfSystemConstants
    {
        public Dictionary<string, decimal> Constants { get; set; }

        public WeightsConstantsWithReferenceKilogram()
        {
            Constants = new Dictionary<string, decimal>()
            {
                { "Milligram",     Decimal.Parse("0,00001")},
                { "Gram",          Decimal.Parse("0,001")},
                { "Carat",         Decimal.Parse("0,0002")},
                { "Ounce",         Decimal.Parse("0,0283495") },
                { "Pound",         Decimal.Parse("0,453592") },
                { "Kilogram",      1 },
                { "Stone",         Decimal.Parse("6,35029") },
                { "Hundredweight", 100 },
                { "Ton",           1000 }
            };
        }
    }
}
