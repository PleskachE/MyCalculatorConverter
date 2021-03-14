using Algorithms.Interface;

using System.Collections.Generic;

namespace Factories.Interface
{
    public interface IFactory
    {
        IEnumerable<IAlgorithm> CreateAlgorithms();
    }
}
