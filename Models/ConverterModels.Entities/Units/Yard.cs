using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Yard")]
    public class Yard : IUnitSystem
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Yard()
        {
            Name = "Yard";
            Type = TypesMeasurementSystems.LengthSystem;
        }

        public Yard(decimal value)
        {
            Name = "Yard";
            Type = TypesMeasurementSystems.LengthSystem;
            Value = value;
        }
    }
}
