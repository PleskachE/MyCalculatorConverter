using Models.Calculator.Abstraction;

namespace Algorithms.Interface
{
    public interface IAlgorithm
    {
        string Result(ICollectionChar listOfReturn);
        string Name { get;}
    }
}
