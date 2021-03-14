using Apps.WPFVersionCC.Configure;
using Common.Containers;
using Factories.Interface;

namespace Factories
{
    public class AlgorithmsFactory : IFactory
    {
        public IContainerOfCustomTypes GetContainerForAlgorithms()
        {
            DependencyInjectionConfig injector = new DependencyInjectionConfig();
            IContainerOfCustomTypes container = new ContainerForAlgorithms(injector.GetAlgorithms());
            return container;
        }
    }
}
