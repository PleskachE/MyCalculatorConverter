using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Milligram")]
    public class Milligram : IUnitSystem
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Milligram()
        {
            Name = "Milligram";
            Type = TypesMeasurementSystems.SystemWeights;
        }

        public Milligram(decimal value)
        {
            Name = "Milligram";
            Type = TypesMeasurementSystems.SystemWeights;
            Value = value;
        }
    }
}
