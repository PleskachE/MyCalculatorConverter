using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Millimeter")]
    public class Millimeter : IUnitSystem
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Millimeter()
        {
            Name = "Millimeter";
            Type = TypesMeasurementSystems.LengthSystem;
        }

        public Millimeter(decimal value)
        {
            Name = "Millimeter";
            Type = TypesMeasurementSystems.LengthSystem;
            Value = value;
        }
    }
}
