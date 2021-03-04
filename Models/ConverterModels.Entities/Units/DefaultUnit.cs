using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Default")]
    public class DefaultUnit : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public DefaultUnit()
        {
            Name = "Default";
            isReferenceUnit = false;
        }
        public DefaultUnit(decimal value)
        {
            Name = "Default";
            isReferenceUnit = false;
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
