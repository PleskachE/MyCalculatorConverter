using Models.ConverterModels.Abstraction.Common;
using System.Collections.Generic;

namespace Models.ConverterModels.Abstraction
{
    public abstract class BaseSystem : ISystem
    {
        public string Name { get; set; }
        public ICollection<BaseUnitSystem> Units { get; set; }
        public TypesMeasurementSystems TypesSystems { get; set; }

        public virtual BaseUnitSystem GetReferenceUnit()
        {
            throw new System.NotImplementedException();
        }
    }
}
