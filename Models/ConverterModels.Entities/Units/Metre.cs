using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Metre")]
    public class Metre : IUnitSystem
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Metre()
        {
            Name = "Metre";
            Type = TypesMeasurementSystems.LengthSystem;
        }

        public Metre(decimal value)
        {
            Name = "Metre";
            Type = TypesMeasurementSystems.LengthSystem;
            Value = value;
        }
    }
}
