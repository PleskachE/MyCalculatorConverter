using ConverterModels.Abstraction;

namespace ConverterModels.Entities.Units
{
    public class Millimeter : BaseUnitSystem
    {
        public Millimeter()
        {
            Name = "Милиметр";
        }

        public Millimeter(decimal value)
        {
            Name = "Милиметр";
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
