using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;
using System;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Inch")]
    public class Inch : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Inch()
        {
            Name = "Inch";
            Type = TypesMeasurementSystems.LengthSystem;
            isReferenceUnit = false;
        }

        public Inch(decimal value)
        {
            Name = "Inch";
            Type = TypesMeasurementSystems.LengthSystem;
            isReferenceUnit = false;
            Value = value;
        }

        public decimal RelationToReferenceUnit()
        {
            return (Decimal.Parse("2.54") * Value);
        }

        public decimal RelationToThisUnit(decimal unitValue)
        {
            return (unitValue / Decimal.Parse("2.54"));
        }
    }
}
