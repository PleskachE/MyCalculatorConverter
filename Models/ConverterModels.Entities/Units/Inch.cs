using Models.ConverterModels.Abstraction;

using System;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Inch")]
    public class Inch : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }

        public Inch()
        {
            Name = "Inch";
        }

        public Inch(decimal value)
        {
            Name = "Inch";
            Value = value;
        }

        public decimal RelationToReferenceUnit()
        {
            return (Decimal.Parse("2.54") * Value);
        }

        public decimal RelationToThisUnit(decimal unitValue)
        {
            return (unitValue / Decimal.Parse("2.54"));
        }
    }
}
