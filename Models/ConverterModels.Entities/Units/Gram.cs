using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Gram")]
    public class Gram : IUnitSystem
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Gram()
        {
            Name = "Gram";
            Type = TypesMeasurementSystems.SystemWeights;
        }

        public Gram(decimal value)
        {
            Name = "Gram";
            Type = TypesMeasurementSystems.SystemWeights;
            Value = value;
        }
    }
}
