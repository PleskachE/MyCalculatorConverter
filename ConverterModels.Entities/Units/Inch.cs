using ConverterModels.Abstraction;
using System;

namespace ConverterModels.Entities.Units
{
    public class Inch : BaseUnitSystem
    {
        public Inch()
        {
            Name = "Дюйм";
        }

        public Inch(decimal value)
        {
            Name = "Дюйм";
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
