using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Stone")]
    public class Stone : IUnitSystem
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Stone()
        {
            Name = "Stone";
            Type = TypesMeasurementSystems.SystemWeights;
        }

        public Stone(decimal value)
        {
            Name = "Stone";
            Type = TypesMeasurementSystems.SystemWeights;
            Value = value;
        }
    }
}
