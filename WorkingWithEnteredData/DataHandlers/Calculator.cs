using WorkingWithEnterdData.Algorithms;
using WorkingWithEnterdData.Algorithms.Abstraction;
using WorkingWithEnteredData.Common;
using WorkingWithEnteredData.DataHandlers.Abstractions;

namespace WorkingWithEnteredData.DataHandlers
{
    public class Calculator : InputDataHandler
    {
        #region Fields

        private ICalculationAlgorithm _calculationAlgorithm;

        #endregion

        #region Properties

        private double _leftNumber = 0;
        public double LeftNumber
        {
            get
            {
                return _leftNumber;
            }
            set
            {
                _leftNumber = value;
            }
        }

        private double _rightNumber = 0;
        public double RightNumber
        {
            get
            {
                return _rightNumber;
            }
            set
            {
                _rightNumber = value;
            }
        }

        #endregion

        #region Methods

        public double Calculation(Operation operation)
        {
            switch (operation)
            {
                case Operation.Summation:
                    _calculationAlgorithm = new Summation();
                    break;
                case Operation.Subtraction:
                    _calculationAlgorithm = new Subtraction();
                    break;
                case Operation.Multiply:
                    _calculationAlgorithm = new Multiply();
                    break;
                case Operation.Division:
                    _calculationAlgorithm = new Division();
                    break;
            }

            return _calculationAlgorithm.Result(_leftNumber, _rightNumber);
        }

        #endregion
    }

}
