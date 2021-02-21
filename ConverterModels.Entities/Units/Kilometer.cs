using ConverterModels.Abstraction;

namespace ConverterModels.Entities.Units
{
    public class Kilometer : BaseUnitSystem
    {
        public Kilometer()
        {
            Name = "Километр";
        }

        public override decimal RelationToReferenceUnit(decimal unitValue)
        {
            return (100000 / unitValue);
        }
    }
}
