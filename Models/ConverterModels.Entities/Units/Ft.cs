using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Ft")]
    public class Ft : IUnitSystem
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Ft()
        {
            Name = "Ft";
            Type = TypesMeasurementSystems.LengthSystem;
        }

        public Ft(decimal value)
        {
            Name = "Ft";
            Type = TypesMeasurementSystems.LengthSystem;
            Value = value;
        }
    }
}
