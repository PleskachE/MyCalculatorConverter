using System.ComponentModel;

namespace Models.ConverterModels.Abstraction.Common
{
    [Description("Default")]
    public class DefaultUnit : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }

        public DefaultUnit()
        {
            Name = "Default";
            isReferenceUnit = false;
            Value = 0;
        }
        public DefaultUnit(decimal value)
        {
            Name = "Default";
            isReferenceUnit = false;
            Value = value;
        }
    }
}
