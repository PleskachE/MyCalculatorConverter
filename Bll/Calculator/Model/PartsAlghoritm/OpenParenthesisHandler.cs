using Bll.Calculator.Converters;
using Bll.Calculator.Model.Abstraction;

using System.Collections.Generic;

namespace Bll.Calculator.Model.PartsAlghoritm
{
    public class OpenParenthesisHandler : PartAlgorithm
    {
        #region Fields

        private OperationConverter _operationConverter = new OperationConverter();

        #endregion

        #region Ctor

        public OpenParenthesisHandler(List<BaseSymbal> listOfReturn, List<BaseSymbal> operationStack)
        {
            OperationStack = operationStack;
            ListOfReturn = listOfReturn;
        }

        #endregion

        #region Methods

        public override void Processing(string symbal)
        {
            var operation = _operationConverter.StringToOperation(symbal);
            OperationStack.Add(operation);
        }

        #endregion
    }
}
