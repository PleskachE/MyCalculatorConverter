using ConverterModels.Abstraction;
using ConverterModels.Entities.Units;

using System.Collections.Generic;
using System.Linq;

namespace ConverterModels.Entities
{
    public class LengthCalculus : BaseSystem, ISystem
    {
        public LengthCalculus()
        {
            Name = "Система мер длинны";
            TypesSystems = TypesCalculusSystems.LengthSystem;
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

        public IUnitSystem GetReferenceUnit()
        {
            return Units.ToList().Find(x => x.isReferenceUnit == true);
        }
    }
}
