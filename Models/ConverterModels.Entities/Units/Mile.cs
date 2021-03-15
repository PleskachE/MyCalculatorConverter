using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Mile")]
    public class Mile : IUnitSystem
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Mile()
        {
            Name = "Mile";
            Type = TypesMeasurementSystems.LengthSystem;
        }

        public Mile(decimal value)
        {
            Name = "Mile";
            Type = TypesMeasurementSystems.LengthSystem;
            Value = value;
        }
    }
}
