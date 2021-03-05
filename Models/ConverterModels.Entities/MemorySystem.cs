using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;
using Models.ConverterModels.Entities.Units;

using System.Collections.Generic;

namespace Models.ConverterModels.Entities
{
    public class MemorySystem : BaseSystem
    {
        public MemorySystem()
        {
            Name = "Memory Elements";
            TypesSystems = TypesMeasurementSystems.SystemMemory;
            Units = new List<IUnitSystem>()
            {
                new Bit(),
                new Byte(),
                new Kilobyte(),
                new Megabyte()
            };
        }
    }
}
