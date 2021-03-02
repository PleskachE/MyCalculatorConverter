using ConverterModels.Abstraction;
using System.ComponentModel;

namespace ConverterModels.Entities.Units
{
    [Description("Decimeter")]
    public class Decimeter : BaseUnitSystem
    {
        public Decimeter()
        {
            Name = "Decimeter";
        }

        public Decimeter(decimal value)
        {
            Name = "Decimeter";
            Value = value;
        }

        public override decimal RelationToReferenceUnit()
        {
            return (Value * 10);
        }

        public override decimal RelationToThisUnit(decimal unitValue)
        {
            return (unitValue / 10);
        }
    }
}
