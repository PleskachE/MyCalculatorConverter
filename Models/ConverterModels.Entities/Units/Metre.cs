using Models.ConverterModels.Abstraction;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Metre")]
    public class Metre : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }

        public Metre()
        {
            Name = "Metre";
        }

        public Metre(decimal value)
        {
            Name = "Metre";
            Value = value;
        }

        public decimal RelationToReferenceUnit()
        {
            return (100 * Value);
        }

        public decimal RelationToThisUnit(decimal unitValue)
        {
            return (unitValue / 100);
        }
    }
}
