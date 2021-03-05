using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Bit")]
    public class Bit : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }
        public Bit()
        {
            Name = "Bit";
            Type = TypesMeasurementSystems.SystemMemory;
            isReferenceUnit = false;
        }

        public Bit(decimal value)
        {
            Name = "Bit";
            Type = TypesMeasurementSystems.SystemMemory;
            isReferenceUnit = false;
            Value = value;
        }

        public decimal RelationToReferenceUnit()
        {
            return Value / 8;
        }

        public decimal RelationToThisUnit(decimal unitValue)
        {
            return unitValue * 8;
        }
    }
}
