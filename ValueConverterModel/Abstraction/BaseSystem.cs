using System.Collections.Generic;

namespace ValueConverterModel.Abstraction
{
    public abstract class BaseSystem 
    {
        public string Name { get; set; }
        public ICollection<IUnitSystem> UnitOfMeasurements { get; set; }
    }
}
