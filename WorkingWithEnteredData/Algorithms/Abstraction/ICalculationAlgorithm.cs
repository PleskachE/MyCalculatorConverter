using MyСalculatorConverter.Model;

namespace WorkingWithEnterdData.Algorithms.Abstraction
{
    public interface ICalculationAlgorithm
    {
        Number Result(Number leftNumber, Number rightNumber);
    }
}
