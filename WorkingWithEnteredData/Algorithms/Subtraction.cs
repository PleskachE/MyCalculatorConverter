using WorkingWithEnterdData.Algorithms.Abstraction;
using WorkingWithEnteredData.Converters;

namespace WorkingWithEnterdData.Algorithms
{
    public class Subtraction : ICalculationAlgorithm
    {
        private NumbersConverter _converter = new NumbersConverter();
        public string Result(string leftNumber, string rightNumber)
        {
            double _leftNumber = _converter.StringToDouble(leftNumber);
            double _rightNumber = _converter.StringToDouble(rightNumber);
            double _result;
            try
            {
                _result = _leftNumber - _rightNumber;
            }
            catch
            {
                _result = 0;
            }
            return _result.ToString();
        }
    }
}
