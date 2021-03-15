using Common;
using Common.Loaders;

using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System;
using System.Collections.Generic;

namespace Models.ConverterModels.Entities
{
    public class MemorySystem : BaseSystem
    {
        private ICollection<Type> collection = ClassCollectionLoader
                .loadsTypesImplementInterface(AssemblyLoader
                .LoadsAssemblyOnPath(Constants.ValuesConverterEntitiesPath), Constants.ValuesConverterEntitiesNameInterface);
        public MemorySystem()
        {
            Name = "Memory Elements";
            TypesSystems = TypesMeasurementSystems.SystemMemory;
            Units = new List<IUnitSystem>();
            LoadUnits(collection);
        }
    }
}
