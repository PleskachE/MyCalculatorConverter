using Common;
using Common.Loaders;

using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System;
using System.Collections.Generic;

namespace Models.ConverterModels.Entities
{
    public class LengthSystem : BaseSystem
    {
        private ICollection<Type> collection = ClassCollectionLoader
                 .loadsTypesImplementInterface(AssemblyLoader
                 .LoadsAssemblyOnPath(Constants.ValuesConverterEntitiesPath), Constants.ValuesConverterEntitiesNameInterface);
        public LengthSystem()
        {
            Name = "Length Elements";
            TypesSystems = TypesMeasurementSystems.LengthSystem;
            Units = new List<IUnitSystem>();
            LoadUnits(collection);
        }
    }
}
