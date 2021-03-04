using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Hundredweight")]
    public class Hundredweight : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Hundredweight()
        {
            Name = "Hundredweight";
            Type = TypesMeasurementSystems.SystemWeights;
            isReferenceUnit = false;
        }

        public Hundredweight(decimal value)
        {
            Name = "Hundredweight";
            Type = TypesMeasurementSystems.SystemWeights;
            isReferenceUnit = false;
            Value = value;
        }

        public decimal RelationToReferenceUnit()
        {
            return Value * 100;
        }

        public decimal RelationToThisUnit(decimal unitValue)
        {
            return unitValue / 100;
        }
    }
}
