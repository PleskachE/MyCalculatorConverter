using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Kilobyte")]
    public class Kilobyte : IUnitSystem
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }
        public Kilobyte()
        {
            Name = "Kilobyte";
            Type = TypesMeasurementSystems.SystemMemory;
        }

        public Kilobyte(decimal value)
        {
            Name = "Kilobyte";
            Type = TypesMeasurementSystems.SystemMemory;
            Value = value;
        }
    }
}
