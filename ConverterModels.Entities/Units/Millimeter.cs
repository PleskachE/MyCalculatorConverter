using ConverterModels.Abstraction;

namespace ConverterModels.Entities.Units
{
    public class Millimeter : BaseUnitSystem
    {
        public Millimeter()
        {
            Name = "Милиметр";
        }

        public override decimal RelationToReferenceUnit(decimal unitValue)
        {
            return (10 * unitValue);
        }
    }
}
