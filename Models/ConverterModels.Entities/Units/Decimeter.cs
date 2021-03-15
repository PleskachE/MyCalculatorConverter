using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Decimeter")]
    public class Decimeter : IUnitSystem
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Decimeter()
        {
            Name = "Decimeter";
            Type = TypesMeasurementSystems.LengthSystem;
        }

        public Decimeter(decimal value)
        {
            Name = "Decimeter";
            Type = TypesMeasurementSystems.LengthSystem;
            Value = value;
        }
    }
}
