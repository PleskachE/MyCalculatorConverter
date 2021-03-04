using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;
using System;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Carat")]
    public class Carat : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Carat()
        {
            Name = "Carat";
            Type = TypesMeasurementSystems.SystemWeights;
            isReferenceUnit = false;
        }

        public Carat(decimal value)
        {
            Name = "Carat";
            Type = TypesMeasurementSystems.SystemWeights;
            isReferenceUnit = false;
            Value = value;
        }

        public decimal RelationToReferenceUnit()
        {
            return Value * Decimal.Parse("0.0002");
        }

        public decimal RelationToThisUnit(decimal unitValue)
        {
            return unitValue / Decimal.Parse("0.0002");
        }
    }
}
