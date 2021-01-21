using WorkingWithEnterdData.Algorithms.Abstraction;

namespace WorkingWithEnterdData.Algorithms
{
    public class Summation : ICalculationAlgorithm
    {
        public double Result(double leftNumber, double rightNumber)
        {
            double result;
            try
            {
                result = leftNumber + rightNumber;
            }
            catch
            {
                result = 0;
            }
            return result;
        }
    }
}
