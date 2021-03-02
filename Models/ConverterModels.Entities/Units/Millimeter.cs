using Models.ConverterModels.Abstraction;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Millimeter")]
    public class Millimeter : BaseUnitSystem
    {
        public Millimeter()
        {
            Name = "Millimeter";
        }

        public Millimeter(decimal value)
        {
            Name = "Millimeter";
            Value = value;
        }

        public override decimal RelationToReferenceUnit()
        {
            return (Value / 10);
        }

        public override decimal RelationToThisUnit(decimal unitValue)
        {
            return (unitValue * 10);
        }
    }
}
