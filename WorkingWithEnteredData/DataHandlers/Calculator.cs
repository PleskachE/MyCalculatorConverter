using WorkingWithEnterdData.Algorithms;
using WorkingWithEnterdData.Algorithms.Abstraction;
using WorkingWithEnteredData.Common;
using WorkingWithEnteredData.Converters;
using WorkingWithEnteredData.DataHandlers.Abstractions;

namespace WorkingWithEnteredData.DataHandlers
{
    public class Calculator : InputDataHandler
    {
        #region Fields

        private ICalculationAlgorithm _calculationAlgorithm;
        private OperationConverter _operationConverter;
        private NumbersConverter _numbersConverter;

        #endregion

        public Calculator()
        {
            _operationConverter = new OperationConverter();
            _numbersConverter = new NumbersConverter();
        }

        #region Methods

        public override string Calculation(string operation)
        {
            Operation _operation = _operationConverter.StringToOperation(operation);
            switch (_operation)
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
            var _result = _calculationAlgorithm.Result(_numbersConverter.StringToDouble(LeftNumber), _numbersConverter.StringToDouble(RightNumber));
            Result = _result.ToString();
            return Result;
        }

        #endregion
    }

}
