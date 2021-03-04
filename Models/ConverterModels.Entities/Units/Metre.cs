using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Metre")]
    public class Metre : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public Metre()
        {
            Name = "Metre";
            Type = TypesMeasurementSystems.LengthSystem;
            isReferenceUnit = false;
        }

        public Metre(decimal value)
        {
            Name = "Metre";
            Type = TypesMeasurementSystems.LengthSystem;
            isReferenceUnit = false;
            Value = value;
        }

        public decimal RelationToReferenceUnit()
        {
            return (100 * Value);
        }

        public decimal RelationToThisUnit(decimal unitValue)
        {
            return (unitValue / 100);
        }
    }
}
