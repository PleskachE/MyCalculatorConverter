using Models.ConverterModels.Abstraction.Common;

using System.Collections.Generic;

namespace Models.ConverterModels.Abstraction
{
    public interface ISystem
    {
        string Name { get; set; }
        ICollection<IUnitSystem> Units { get; set; }
        TypesMeasurementSystems TypesSystems { get; set; }
    }
}
