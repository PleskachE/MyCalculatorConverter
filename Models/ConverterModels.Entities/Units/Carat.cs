using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Carat")]
    public class Carat : IUnitSystem
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Carat()
        {
            Name = "Carat";
            Type = TypesMeasurementSystems.SystemWeights;
        }

        public Carat(decimal value)
        {
            Name = "Carat";
            Type = TypesMeasurementSystems.SystemWeights;
            Value = value;
        }
    }
}
