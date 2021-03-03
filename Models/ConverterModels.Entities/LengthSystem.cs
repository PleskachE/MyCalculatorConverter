using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;
using Models.ConverterModels.Entities.Units;

using System.Collections.Generic;
using System.Linq;

namespace Models.ConverterModels.Entities
{
    public class LengthSystem : BaseSystem
    {
        public LengthSystem()
        {
            Name = "Система мер длинны";
            TypesSystems = TypesMeasurementSystems.LengthSystem;
            Units = new List<IUnitSystem>()
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

        public override IUnitSystem GetReferenceUnit()
        {
            return Units.ToList().Find(x => x.isReferenceUnit == true);
        }
    }
}
