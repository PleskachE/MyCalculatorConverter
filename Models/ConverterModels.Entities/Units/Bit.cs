using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Bit")]
    public class Bit : IUnitSystem
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }
        public Bit()
        {
            Name = "Bit";
            Type = TypesMeasurementSystems.SystemMemory;
        }

        public Bit(decimal value)
        {
            Name = "Bit";
            Type = TypesMeasurementSystems.SystemMemory;
            Value = value;
        }
    }
}
