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

        public override decimal RelationToReferenceUnit(decimal unitValue)
        {
            return (Decimal.Parse("2.54") * unitValue);
        }
    }
}
