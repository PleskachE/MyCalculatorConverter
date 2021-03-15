using Models.ConverterModels.Abstraction.Common;

namespace Models.ConverterModels.Abstraction
{
    public interface IUnitSystem
    {
        decimal Value { get; set; }
        string Name { get; set; }
        TypesMeasurementSystems Type { get; set; }
    }
}
