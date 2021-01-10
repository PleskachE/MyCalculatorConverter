using MyСalculatorConverter.Model;

namespace MyCalculatorConverter.Algorithms.Abstraction
{
    public interface ICalculationAlgorithm
    {
        Number Result(Number leftNumber, Number rightNumber);
    }
}
