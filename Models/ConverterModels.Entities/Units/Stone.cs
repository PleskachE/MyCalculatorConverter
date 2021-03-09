using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;
using System;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Stone")]
    public class Stone : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Stone()
        {
            Name = "Stone";
            Type = TypesMeasurementSystems.SystemWeights;
            isReferenceUnit = false;
        }

        public Stone(decimal value)
        {
            Name = "Stone";
            Type = TypesMeasurementSystems.SystemWeights;
            isReferenceUnit = false;
            Value = value;
        }

        public decimal RelationToReferenceUnit()
        {
            return Value * Decimal.Parse("6,35029");
        }

        public decimal RelationToThisUnit(decimal unitValue)
        {
            return unitValue / Decimal.Parse("6,35029");
        }
    }
}
