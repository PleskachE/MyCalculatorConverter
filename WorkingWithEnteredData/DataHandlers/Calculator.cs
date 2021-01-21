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

        #region Methods

        public override double Calculation(Operation operation)
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
            Result = _calculationAlgorithm.Result(LeftNumber, RightNumber);
            return Result;
        }

        #endregion
    }

}
