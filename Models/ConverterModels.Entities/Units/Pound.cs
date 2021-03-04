using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;
using System;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Pound")]
    public class Pound : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Pound()
        {
            Name = "Pound";
            Type = TypesMeasurementSystems.SystemWeights;
            isReferenceUnit = false;
        }

        public Pound(decimal value)
        {
            Name = "Pound";
            Type = TypesMeasurementSystems.SystemWeights;
            isReferenceUnit = false;
            Value = value;
        }

        public decimal RelationToReferenceUnit()
        {
            return Value * Decimal.Parse("0.453592");
        }

        public decimal RelationToThisUnit(decimal unitValue)
        {
            return unitValue / Decimal.Parse("0.453592");
        }
    }
}
