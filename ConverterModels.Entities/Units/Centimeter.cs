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

        public override decimal RelationToReferenceUnit(decimal unitValue)
        {
            return unitValue;
        }
    }
}
