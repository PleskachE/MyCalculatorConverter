using Models.ConverterModels.Abstraction;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Millimeter")]
    public class Millimeter : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }

        public Millimeter()
        {
            Name = "Millimeter";
        }

        public Millimeter(decimal value)
        {
            Name = "Millimeter";
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
