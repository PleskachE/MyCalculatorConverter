using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Hundredweight")]
    public class Hundredweight : IUnitSystem
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Hundredweight()
        {
            Name = "Hundredweight";
            Type = TypesMeasurementSystems.SystemWeights;
        }

        public Hundredweight(decimal value)
        {
            Name = "Hundredweight";
            Type = TypesMeasurementSystems.SystemWeights;
            Value = value;
        }
    }
}
