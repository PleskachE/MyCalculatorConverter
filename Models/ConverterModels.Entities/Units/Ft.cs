using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;
using System;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Ft")]
    public class Ft : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Ft()
        {
            Name = "Ft";
            Type = TypesMeasurementSystems.LengthSystem;
            isReferenceUnit = false;
        }

        public Ft(decimal value)
        {
            Name = "Ft";
            Type = TypesMeasurementSystems.LengthSystem;
            isReferenceUnit = false;
            Value = value;
        }

        public decimal RelationToReferenceUnit()
        {
            return (Decimal.Parse("30,48") * Value);
        }

        public decimal RelationToThisUnit(decimal unitValue)
        {
            return (unitValue / Decimal.Parse("30,48"));
        }
    }
}
