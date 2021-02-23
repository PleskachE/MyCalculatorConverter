using ConverterModels.Abstraction;

namespace ConverterModels.Entities.Units
{
    public class Metre : BaseUnitSystem
    {
        public Metre()
        {
            Name = "Метр";
        }

        public Metre(decimal value)
        {
            Name = "Метр";
            Value = value;
        }

        public override decimal RelationToReferenceUnit()
        {
            return (100 * Value);
        }

        public override decimal RelationToThisUnit(decimal unitValue)
        {
            return (unitValue / 100);
        }
    }
}
