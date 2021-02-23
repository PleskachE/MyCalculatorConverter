using ConverterModels.Abstraction;

namespace ConverterModels.Entities.Units
{
    public class Decimeter : BaseUnitSystem
    {
        public Decimeter()
        {
            Name = "Дециметр";
        }

        public Decimeter(decimal value)
        {
            Name = "Дециметр";
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
