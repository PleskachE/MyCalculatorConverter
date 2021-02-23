using ConverterModels.Abstraction;
using System;

namespace ConverterModels.Entities.Units
{
    public class Mile : BaseUnitSystem
    {
        public Mile()
        {
            Name = "Миля";
        }

        public Mile(decimal value)
        {
            Name = "Миля";
            Value = value;
        }

        public override decimal RelationToReferenceUnit()
        {
            return (Decimal.Parse("160934.4") * Value);
        }

        public override decimal RelationToThisUnit(decimal unitValue)
        {
            return (unitValue / Decimal.Parse("160934.4"));
        }
    }
}
