using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;
using Models.ConverterModels.Entities.Units;

using System.Collections.Generic;

namespace Models.ConverterModels.Entities
{
    public class LengthSystem : BaseSystem
    {
        public LengthSystem()
        {
            Name = "Length Elements";
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
    }
}
