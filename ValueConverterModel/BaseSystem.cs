using System.Collections.Generic;

namespace ConverterModels.Abstraction
{
    public abstract class BaseSystem
    {
        public string Name { get; set; }
        public ICollection<BaseUnitSystem> Units { get; set; }
        public TypesMeasurementSystems TypesSystems { get; set; }
    }
}
