using Models.ConverterModels.Abstraction;
using System;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Mile")]
    public class Mile : BaseUnitSystem
    {
        public Mile()
        {
            Name = "Mile";
        }

        public Mile(decimal value)
        {
            Name = "Mile";
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
