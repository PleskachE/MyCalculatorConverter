using ConverterModels.Abstraction;
using System.ComponentModel;

namespace ConverterModels.Entities.Units
{
    [Description ("Centimeter")]
    public class Centimeter : BaseUnitSystem
    {
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

        public override decimal RelationToReferenceUnit()
        {
            return Value;
        }

        public override decimal RelationToThisUnit(decimal unitValue)
        {
            return unitValue;
        }
    }
}
