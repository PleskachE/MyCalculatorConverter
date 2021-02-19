
namespace ValueConverterModel.Abstraction
{
    public interface IUnitOfMeasurement
    {
        decimal RelationToReferenceUnit(decimal ValueReferenceUnit);
    }
}
