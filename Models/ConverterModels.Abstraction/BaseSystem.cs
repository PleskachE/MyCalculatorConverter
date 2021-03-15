using Models.ConverterModels.Abstraction.Common;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.ConverterModels.Abstraction
{
    public abstract class BaseSystem : ISystem
    {
        public string Name { get; set; }
        public ICollection<IUnitSystem> Units { get; set; }
        public TypesMeasurementSystems TypesSystems { get; set; }

        protected void LoadUnits(ICollection<Type> collection)
        {
            if (!collection.Any())
            {
                Units.Add(new DefaultUnit());
            }
            Units = collection
                .Select(Instance)
                .Where(IsNeededTypeSystem)
                .ToList();
        }
        private bool IsNeededTypeSystem(IUnitSystem unitSystem)
        {
            return unitSystem.Type == TypesSystems;
        }
        private IUnitSystem Instance(Type type)
        {
            return (IUnitSystem)Activator.CreateInstance(type);
        }
    }
}
