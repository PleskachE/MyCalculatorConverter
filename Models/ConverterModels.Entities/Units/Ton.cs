using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Ton")]
    public class Ton : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Ton()
        {
            Name = "Ton";
            Type = TypesMeasurementSystems.SystemWeights;
            isReferenceUnit = false;
        }

        public Ton(decimal value)
        {
            Name = "Ton";
            Type = TypesMeasurementSystems.SystemWeights;
            isReferenceUnit = false;
            Value = value;
        }

        public decimal RelationToReferenceUnit()
        {
            return Value * 1000;
        }

        public decimal RelationToThisUnit(decimal unitValue)
        {
            return unitValue / 1000;
        }
    }
}
