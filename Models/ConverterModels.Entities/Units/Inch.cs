using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Inch")]
    public class Inch : IUnitSystem
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Inch()
        {
            Name = "Inch";
            Type = TypesMeasurementSystems.LengthSystem;
        }

        public Inch(decimal value)
        {
            Name = "Inch";
            Type = TypesMeasurementSystems.LengthSystem;
            Value = value;
        }
    }
}
