using ConverterModels.Abstraction;
using System;

namespace ConverterModels.Entities.Units
{
    public class Ft : BaseUnitSystem
    {
        public Ft()
        {
            Name = "Фут";
        }

        public Ft(decimal value)
        {
            Name = "Фут";
            Value = value;
        }

        public override decimal RelationToReferenceUnit()
        {
            return (Decimal.Parse("30.48") * Value);
        }

        public override decimal RelationToThisUnit(decimal unitValue)
        {
            return (unitValue / Decimal.Parse("30.48"));
        }
    }
}
