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

        public override decimal RelationToReferenceUnit(decimal unitValue)
        {
            return (Decimal.Parse("160934.4") * unitValue);
        }
    }
}
