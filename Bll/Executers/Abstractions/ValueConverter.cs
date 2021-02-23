using ConverterModels.Abstraction;

namespace Bll.Executers.Abstractions
{
    public abstract class ValueConverter
    {
        public ISystem SystemCalculus { get; set; }
    }
}
