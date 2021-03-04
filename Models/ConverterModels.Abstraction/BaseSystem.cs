using Models.ConverterModels.Abstraction.Common;

using System.Collections.Generic;
using System.Linq;

namespace Models.ConverterModels.Abstraction
{
    public abstract class BaseSystem : ISystem
    {
        public string Name { get; set; }
        public ICollection<IUnitSystem> Units { get; set; }
        public TypesMeasurementSystems TypesSystems { get; set; }

        public IUnitSystem GetReferenceUnit()
        {
            return Units.ToList().Find(x => x.isReferenceUnit == true);
        }
    }
}
