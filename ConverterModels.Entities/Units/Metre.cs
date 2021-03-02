using ConverterModels.Abstraction;
using System.ComponentModel;

namespace ConverterModels.Entities.Units
{
    [Description("Metre")]
    public class Metre : BaseUnitSystem
    {
        public Metre()
        {
            Name = "Metre";
        }

        public Metre(decimal value)
        {
            Name = "Metre";
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
