using ConverterModels.Abstraction;

namespace ConverterModels.Entities.Units
{
    public class Kilometer : BaseUnitSystem
    {
        public Kilometer()
        {
            Name = "Километр";
        }

        public Kilometer(decimal value)
        {
            Name = "Километр";
            Value = value;
        }

        public override decimal RelationToReferenceUnit()
        {
            return (100000 * Value);
        }

        public override decimal RelationToThisUnit(decimal unitValue)
        {
            return (unitValue / 100000);
        }
    }
}
