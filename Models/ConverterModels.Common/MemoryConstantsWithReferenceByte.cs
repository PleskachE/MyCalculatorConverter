using Models.ConverterModels.Common.Interface;

using System;
using System.Collections.Generic;

namespace Models.ConverterModels.Common
{
    public class MemoryConstantsWithReferenceByte : IContainerOfSystemConstants
    {
        public Dictionary<string, decimal> Constants { get; set; }

        public MemoryConstantsWithReferenceByte()
        {
            Constants = new Dictionary<string, decimal>()
            {
                { "Bit",      Decimal.Parse("0,8") },
                { "Byte",     1 },
                { "Kilobyte", 1024 },
                { "Megabyte", Decimal.Parse(Math.Pow(10, 6).ToString()) }
            };
        }
    }
}
