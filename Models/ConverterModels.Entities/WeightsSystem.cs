using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;
using Models.ConverterModels.Entities.Units;

using System.Collections.Generic;

namespace Models.ConverterModels.Entities
{
    public class WeightsSystem : BaseSystem
    {

        public WeightsSystem()
        {
            Name = "Mass Elements";
            TypesSystems = TypesMeasurementSystems.SystemWeights;
            Units = new List<IUnitSystem>()
            {
                new Milligram(),
                new Gram(),
                new Kilogram(),
                new Hundredweight(),
                new Ton(),
                new Carat(),
                new Ounce(),
                new Stone(),
                new Pound()
            };
        }
    }
}
