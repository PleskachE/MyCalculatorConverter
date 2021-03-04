using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;
using System;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Ounce")]
    public class Ounce : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Ounce()
        {
            Name = "Ounce";
            Type = TypesMeasurementSystems.SystemWeights;
            isReferenceUnit = false;
        }

        public Ounce(decimal value)
        {
            Name = "Ounce";
            Type = TypesMeasurementSystems.SystemWeights;
            isReferenceUnit = false;
            Value = value;
        }

        public decimal RelationToReferenceUnit()
        {
            return Value * Decimal.Parse("0.0283495");
        }

        public decimal RelationToThisUnit(decimal unitValue)
        {
            return unitValue / Decimal.Parse("0.0283495");
        }
    }
}
