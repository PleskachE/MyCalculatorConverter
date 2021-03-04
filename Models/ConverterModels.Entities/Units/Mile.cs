using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;
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
        public TypesMeasurementSystems Type { get; set; }

        public Mile()
        {
            Name = "Mile";
            Type = TypesMeasurementSystems.LengthSystem;
            isReferenceUnit = false;
        }

        public Mile(decimal value)
        {
            Name = "Mile";
            Type = TypesMeasurementSystems.LengthSystem;
            isReferenceUnit = false;
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
