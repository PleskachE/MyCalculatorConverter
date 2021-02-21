using ConverterModels.Abstraction;

namespace ConverterModels.Entities.Units
{
    public class Decimeter : BaseUnitSystem
    {
        public Decimeter()
        {
            Name = "Дециметр";
        }

        public override decimal RelationToReferenceUnit(decimal unitValue)
        {
            return (10 / unitValue);
        }
    }
}
