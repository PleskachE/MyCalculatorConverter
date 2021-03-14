using Algorithms.Interface;

using System.Collections.Generic;

namespace Common.Containers
{
    public interface IContainerOfCustomTypes
    {
        IEnumerable<IAlgorithm> Algorithms { get; set; }
    }
}
