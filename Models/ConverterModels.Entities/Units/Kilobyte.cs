using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Kilobyte")]
    public class Kilobyte : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }
        public Kilobyte()
        {
            Name = "Kilobyte";
            Type = TypesMeasurementSystems.SystemMemory;
            isReferenceUnit = false;
        }

        public Kilobyte(decimal value)
        {
            Name = "Kilobyte";
            Type = TypesMeasurementSystems.SystemMemory;
            isReferenceUnit = false;
            Value = value;
        }

        public decimal RelationToReferenceUnit()
        {
            return Value * 1024;
        }

        public decimal RelationToThisUnit(decimal unitValue)
        {
            return unitValue / 1024;
        }
    }
}
