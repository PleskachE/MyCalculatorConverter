using Models.ConverterModels.Abstraction;

using System;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Mile")]
    public class Mile : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }

        public Mile()
        {
            Name = "Mile";
        }

        public Mile(decimal value)
        {
            Name = "Mile";
            Value = value;
        }

        public decimal RelationToReferenceUnit()
        {
            return (Decimal.Parse("160934.4") * Value);
        }

        public decimal RelationToThisUnit(decimal unitValue)
        {
            return (unitValue / Decimal.Parse("160934.4"));
        }
    }
}
