using ConverterModels.Abstraction;

namespace ConverterModels.Entities.Units
{
    public class Metre : BaseUnitSystem
    {
        public Metre()
        {
            Name = "Метр";
        }

        public override decimal RelationToReferenceUnit(decimal unitValue)
        {
            return (100 / unitValue);
        }
    }
}
