using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Kilometer")]
    public class Kilometer : IUnitSystem
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Kilometer()
        {
            Name = "Kilometer";
            Type = TypesMeasurementSystems.LengthSystem;
        }

        public Kilometer(decimal value)
        {
            Name = "Kilometer";
            Type = TypesMeasurementSystems.LengthSystem;
            Value = value;
        }
    }
}
