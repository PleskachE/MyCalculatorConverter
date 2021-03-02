using Mdoels.ConverterModels.Abstraction;

namespace Models.ConverterModels.Abstraction
{
    public abstract class BaseUnitSystem : IUnitSystem
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public bool isReferenceUnit = false;

        public virtual decimal RelationToReferenceUnit()
        {
            throw new System.NotImplementedException();
        }

        public virtual decimal RelationToThisUnit(decimal unitValue)
        {
            throw new System.NotImplementedException();
        }
    }
}
