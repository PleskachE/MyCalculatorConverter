using Models.ConverterModels.Abstraction;
using System;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Inch")]
    public class Inch : BaseUnitSystem
    {
        public Inch()
        {
            Name = "Inch";
        }

        public Inch(decimal value)
        {
            Name = "Inch";
            Value = value;
        }

        public override decimal RelationToReferenceUnit()
        {
            return (Decimal.Parse("2.54") * Value);
        }

        public override decimal RelationToThisUnit(decimal unitValue)
        {
            return (unitValue / Decimal.Parse("2.54"));
        }
    }
}
