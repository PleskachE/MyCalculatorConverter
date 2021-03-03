using Models.ConverterModels.Abstraction;

using System;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Ft")]
    public class Ft : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }

        public Ft()
        {
            Name = "Ft";
        }

        public Ft(decimal value)
        {
            Name = "Ft";
            Value = value;
        }

        public decimal RelationToReferenceUnit()
        {
            return (Decimal.Parse("30.48") * Value);
        }

        public decimal RelationToThisUnit(decimal unitValue)
        {
            return (unitValue / Decimal.Parse("30.48"));
        }
    }
}
