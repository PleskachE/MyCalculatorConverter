using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Kilogram")]
    public class Kilogram : IUnitSystem
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }
        public Kilogram()
        {
            Name = "Kilogram";
            Type = TypesMeasurementSystems.SystemWeights;
        }

        public Kilogram(decimal value)
        {
            Name = "Kilogram";
            Type = TypesMeasurementSystems.SystemWeights;;
            Value = value;
        }
    }
}
