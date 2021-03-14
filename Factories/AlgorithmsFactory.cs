using Algorithms.Interface;
using Apps.WPFVersionCC.Configure;
using Factories.Interface;

using System.Collections.Generic;

namespace Factories
{
    public class AlgorithmsFactory : IFactory
    {
        public IEnumerable<IAlgorithm> CreateAlgorithms()
        {
            DependencyInjectionConfig injector = new DependencyInjectionConfig();
            return injector.GetAlgorithms();
        }
    }
}
