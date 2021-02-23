using ConverterModels.Abstraction;

namespace ConverterModels.Entities.Units
{
    public class Centimeter : BaseUnitSystem
    {
        public Centimeter()
        {
            Name = "Сантиметр";
            isReferenceUnit = true;
        }

        public Centimeter(decimal value)
        {
            Name = "Сантиметр";
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
