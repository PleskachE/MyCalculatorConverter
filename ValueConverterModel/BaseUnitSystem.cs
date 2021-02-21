namespace ConverterModels.Abstraction
{
    public abstract class BaseUnitSystem : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit = false;

        public virtual decimal RelationToReferenceUnit(decimal ValueReferenceUnit)
        {
            throw new System.NotImplementedException();
        }
    }
}
