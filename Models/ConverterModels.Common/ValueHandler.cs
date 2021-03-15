using Models.ConverterModels.Common.Interface;

namespace Models.ConverterModels.Common
{
    public class ValueHandler : IValueHandler
    {
        public decimal RelationToReferenceUnit(decimal value, decimal constant)
        {
           return value * constant;
        }

        public decimal RelationToThisUnit(decimal value, decimal constant)
        {
            return value / constant;
        }
    }
}
