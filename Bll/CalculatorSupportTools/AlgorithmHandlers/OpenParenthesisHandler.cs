using Bll.CalculatorSupportTools.Converters;
using Models.Calculator.Abstraction;

namespace Bll.CalculatorSupportTools.AlgorithmHandlers
{
    public class OpenParenthesisHandler : PartAlgorithm
    {
        #region Fields

        private OperationConverter _operationConverter = new OperationConverter();

        #endregion

        #region Ctor

        public OpenParenthesisHandler(ICollectionChar listOfReturn, ICollectionChar operationStack)
        {
            OperationStack = operationStack;
            ListOfReturn = listOfReturn;
        }

        #endregion

        #region Methods

        public override void Processing(string symbal)
        {
            var operation = _operationConverter.StringToOperation(symbal);
            OperationStack.Symbals.Add(operation);
        }

        #endregion
    }
}
