using ConverterModels.Abstraction;
using System;

namespace ConverterModels.Entities.Units
{
    public class Yard : BaseUnitSystem
    {
        public Yard()
        {
            Name = "Ярд";
        }

        public override decimal RelationToReferenceUnit(decimal unitValue)
        {
            return (Decimal.Parse("91.44") * unitValue);
        }
    }
}
