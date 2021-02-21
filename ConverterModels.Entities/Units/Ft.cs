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

        public override decimal RelationToReferenceUnit(decimal unitValue)
        {
            return (Decimal.Parse("30.48") * unitValue);
        }
    }
}
