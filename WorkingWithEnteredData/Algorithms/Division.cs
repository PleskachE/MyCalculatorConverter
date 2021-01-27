using WorkingWithEnterdData.Algorithms.Abstraction;

namespace WorkingWithEnterdData.Algorithms
{
    public class Division : ICalculationAlgorithm
    {
        public double Result(double leftNumber, double rightNumber)
        {
            double _result;
            try
            {
                _result = leftNumber / rightNumber;
            }
            catch
            {
                _result = 0;
            }
            return _result;
        }
    }
}
