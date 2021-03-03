using Models.ConverterModels.Abstraction;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Kilometer")]
    public class Kilometer : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }

        public Kilometer()
        {
            Name = "Kilometer";
        }

        public Kilometer(decimal value)
        {
            Name = "Kilometer";
            Value = value;
        }

        public decimal RelationToReferenceUnit()
        {
            return (100000 * Value);
        }

        public decimal RelationToThisUnit(decimal unitValue)
        {
            return (unitValue / 100000);
        }
    }
}
