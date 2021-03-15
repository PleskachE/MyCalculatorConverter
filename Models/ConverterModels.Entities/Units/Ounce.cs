using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Ounce")]
    public class Ounce : IUnitSystem
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Ounce()
        {
            Name = "Ounce";
            Type = TypesMeasurementSystems.SystemWeights;
        }

        public Ounce(decimal value)
        {
            Name = "Ounce";
            Type = TypesMeasurementSystems.SystemWeights;
            Value = value;
        }
    }
}
