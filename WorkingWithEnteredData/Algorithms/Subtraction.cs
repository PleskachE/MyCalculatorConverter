using WorkingWithEnterdData.Algorithms.Abstraction;
using MyСalculatorConverter.Model;

namespace WorkingWithEnterdData.Algorithms
{
    public class Subtraction : ICalculationAlgorithm
    {
        public Number Result(Number leftNumber, Number rightNumber)
        {
            Number result;
            try
            {
                result = leftNumber - rightNumber;
            }
            catch
            {
                result = new Number(0);
            }
            return result;
        }
    }
}
