using Models.ConverterModels.Abstraction;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description ("Centimeter")]
    public class Centimeter : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }

        public Centimeter()
        {
            Name = "Centimeter";
            isReferenceUnit = true;
        }

        public Centimeter(decimal value)
        {
            Name = "Centimeter";
            Value = value;
            isReferenceUnit = true;
        }

        public decimal RelationToReferenceUnit()
        {
            return Value;
        }

        public decimal RelationToThisUnit(decimal unitValue)
        {
            return unitValue;
        }
    }
}
