using ConverterModels.Abstraction;
using ConverterModels.Entities.Units;

using System.Collections.Generic;
using System.Linq;

namespace ConverterModels.Entities
{
    public class LengthSystem : BaseSystem, ISystem
    {
        public LengthSystem()
        {
            Name = "Система мер длинны";
            TypesSystems = TypesMeasurementSystems.LengthSystem;
            Units = new List<BaseUnitSystem>()
            {
                new Millimeter(),
                new Centimeter(),
                new Decimeter(),
                new Metre(),
                new Kilometer(),
                new Inch(),
                new Ft(),
                new Yard(),
                new Mile()
            };
        }

        public BaseUnitSystem GetReferenceUnit()
        {
            return Units.ToList().Find(x => x.isReferenceUnit == true);
        }
    }
}
