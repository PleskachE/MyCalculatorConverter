using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Kilogram")]
    public class Kilogram : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }
        public Kilogram()
        {
            Name = "Kilogram";
            Type = TypesMeasurementSystems.SystemWeights;
            isReferenceUnit = true;
        }

        public Kilogram(decimal value)
        {
            Name = "Kilogram";
            Type = TypesMeasurementSystems.SystemWeights;
            isReferenceUnit = true;
            Value = value;
        }

        public decimal RelationToReferenceUnit()
        {
            return Value;
        }

        public decimal RelationToThisUnit(decimal unitValue)
        {
            return unitValue;
        }
    }
}
