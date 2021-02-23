namespace ConverterModels.Abstraction
{
    public interface IUnitSystem
    {
        decimal RelationToReferenceUnit();
        decimal RelationToThisUnit(decimal unitValue);
    }
}
