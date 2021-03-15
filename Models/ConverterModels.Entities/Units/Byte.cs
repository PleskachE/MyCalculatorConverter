using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Byte")]
    public class Byte : IUnitSystem
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }
        public Byte()
        {
            Name = "Byte";
            Type = TypesMeasurementSystems.SystemMemory;
        }

        public Byte(decimal value)
        {
            Name = "Byte";
            Type = TypesMeasurementSystems.SystemMemory;
            Value = value;
        }
    }
}
