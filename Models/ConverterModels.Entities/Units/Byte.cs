using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Byte")]
    public class Byte : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }
        public Byte()
        {
            Name = "Byte";
            Type = TypesMeasurementSystems.SystemMemory;
            isReferenceUnit = true;
        }

        public Byte(decimal value)
        {
            Name = "Byte";
            Type = TypesMeasurementSystems.SystemMemory;
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
