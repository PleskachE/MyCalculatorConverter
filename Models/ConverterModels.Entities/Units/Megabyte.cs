using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Megabyte")]
    public class Megabyte : IUnitSystem
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }
        public Megabyte()
        {
            Name = "Megabyte";
            Type = TypesMeasurementSystems.SystemMemory;
        }

        public Megabyte(decimal value)
        {
            Name = "Megabyte";
            Type = TypesMeasurementSystems.SystemMemory;
            Value = value;
        }
    }
}
