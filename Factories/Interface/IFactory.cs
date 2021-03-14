using Common.Containers;

namespace Factories.Interface
{
    public interface IFactory
    {
        IContainerOfCustomTypes GetContainerForAlgorithms();
    }
}
