using Algorithms.Interface;

using System.Collections.Generic;

namespace Common.Containers
{
    public class ContainerForAlgorithms : IContainerOfCustomTypes
    {
        public IEnumerable<IAlgorithm> Algorithms { get; set; }
        public ContainerForAlgorithms(IEnumerable<IAlgorithm> algorithms) { Algorithms = algorithms; }
    }
}
