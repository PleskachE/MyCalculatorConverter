using MyCalculatorConverter.Algorithms.Abstraction;
using MyСalculatorConverter.Model;

namespace MyCalculatorConverter.Algorithms
{
    public class Division : ICalculationAlgorithm
    {
        public Number Result(Number leftNumber, Number rightNumber)
        {
            Number result;
            try
            {
                result = leftNumber / rightNumber;
            }
            catch
            {
                result = new Number(0);
            }
            return result;
        }
    }
}
