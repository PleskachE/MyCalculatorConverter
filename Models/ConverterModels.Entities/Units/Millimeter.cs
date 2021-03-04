using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Millimeter")]
    public class Millimeter : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Millimeter()
        {
            Name = "Millimeter";
            Type = TypesMeasurementSystems.LengthSystem;
            isReferenceUnit = false;
        }

        public Millimeter(decimal value)
        {
            Name = "Millimeter";
            Type = TypesMeasurementSystems.LengthSystem;
            isReferenceUnit = false;
            Value = value;
        }

        public decimal RelationToReferenceUnit()
        {
            return (Value / 10);
        }

        public decimal RelationToThisUnit(decimal unitValue)
        {
            return (unitValue * 10);
        }
    }
}
