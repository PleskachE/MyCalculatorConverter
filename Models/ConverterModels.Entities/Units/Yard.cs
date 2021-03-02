using Models.ConverterModels.Abstraction;
using System;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Yard")]
    public class Yard : BaseUnitSystem
    {
        public Yard()
        {
            Name = "Yard";
        }

        public Yard(decimal value)
        {
            Name = "Yard";
            Value = value;
        }

        public override decimal RelationToReferenceUnit()
        {
            return (Decimal.Parse("91.44") * Value);
        }

        public override decimal RelationToThisUnit(decimal unitValue)
        {
            return (unitValue / Decimal.Parse("91.44"));
        }
    }
}
