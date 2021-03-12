﻿using Common;
using Common.Loaders;
using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;
using Models.ConverterModels.Common;

using System;
using System.Collections.Generic;

namespace Models.ConverterModels.Entities
{
    public class MemorySystem : BaseSystem
    {
        private ICollection<Type> collection = ClassCollectionLoader
            .loadsTypesImplementInterface(AssemblyLoader.LoadsAssemblyOnPath(Constants.ValuesConverterEntitiesPath), "IUnitSystem");
        public MemorySystem()
        {
            Name = "Memory Elements";
            TypesSystems = TypesMeasurementSystems.SystemMemory;
            Units = new List<IUnitSystem>();
            LoadUnits();
        }

        private void LoadUnits()
        {
            foreach (var item in collection)
            {
                var unit = (IUnitSystem)Activator.CreateInstance(item);
                if (unit.Type == TypesSystems)
                {
                    Units.Add(unit);
                }
            }
            if(Units.Count == 0)
            {
                Units.Add(new DefaultUnit());
            }
        }
    }
}
