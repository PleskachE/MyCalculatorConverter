using System.Collections.Generic;

namespace ValueConverterModel.Abstraction
{
    public abstract class BaseSystemOfMeasurement 
    {
        public string Name { get; set; }
        public ICollection<IUnitOfMeasurement> UnitOfMeasurements { get; set; }
    }
}
