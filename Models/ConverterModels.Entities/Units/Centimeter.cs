using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description ("Centimeter")]
    public class Centimeter : IUnitSystem
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Centimeter()
        {
            Name = "Centimeter";
            Type = TypesMeasurementSystems.LengthSystem;
        }

        public Centimeter(decimal value)
        {
            Name = "Centimeter";
            Type = TypesMeasurementSystems.LengthSystem;
            Value = value;
        }
    }
}
