using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Pound")]
    public class Pound : IUnitSystem
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Pound()
        {
            Name = "Pound";
            Type = TypesMeasurementSystems.SystemWeights;
        }

        public Pound(decimal value)
        {
            Name = "Pound";
            Type = TypesMeasurementSystems.SystemWeights;
            Value = value;
        }
    }
}
