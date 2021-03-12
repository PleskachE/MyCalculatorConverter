using Bll.Calculator.Converters;
using Models.Calculator.Abstraction;
using Models.Calculator.Common;

using System.Collections.Generic;
using System.Linq;

namespace Bll.Calculator.AlgorithmHandlers
{
    public class OperationHandler : PartAlgorithm
    {
        #region Fields

        private OperationConverter _operationConverter = new OperationConverter();

        #endregion

        #region Ctor

        public OperationHandler(List<BaseSymbal> listOfReturn, List<BaseSymbal> operationStack)
        {
            OperationStack = operationStack;
            ListOfReturn = listOfReturn;
        }

        #endregion

        #region Methods

        public override void Processing(string symbal)
        {
            var operation = _operationConverter.StringToOperation(symbal);
            if (OperationStack.Count == 0)
            {
                OperationStack.Add(operation);
            }
            else
            {
                var lastOperation = OperationStack.Last();
                if (operation.Priority == Priority.High && lastOperation.Priority == Priority.Low || OperationStack.Last().Value == "(")
                {
                    OperationStack.Add(operation);
                }
                else
                {
                    ListOfReturn.Add(OperationStack.Last());
                    OperationStack.RemoveAt(OperationStack.Count - 1);
                    OperationStack.Add(operation);
                }
            }
        }

        #endregion
    }
}
