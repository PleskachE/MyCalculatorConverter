
namespace Models.ConverterModels.Common.Interface
{
    public interface IValueHandler
    {
        decimal RelationToReferenceUnit(decimal value, decimal constant);
        decimal RelationToThisUnit(decimal value, decimal constant);
    }
}
