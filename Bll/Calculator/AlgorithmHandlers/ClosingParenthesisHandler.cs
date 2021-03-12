using Models.Calculator.Abstraction;

using System.Collections.Generic;
using System.Linq;

namespace Bll.Calculator.AlgorithmHandlers
{
    public class ClosingParenthesisHandler : PartAlgorithm
    {

        #region Ctor

        public ClosingParenthesisHandler(List<BaseSymbal> listOfReturn, List<BaseSymbal> operationStack)
        {
            ListOfReturn = listOfReturn;
            OperationStack = operationStack;
        }

        #endregion

        #region Methods

        public override void Processing(string symbal)
        {
            while (OperationStack.Count != 0)
            {
                if (OperationStack.Last().Value == "(" || OperationStack.Last().Value == ")")
                {
                    OperationStack.Remove(OperationStack.Last());
                }
                else
                {
                    ListOfReturn.Add(OperationStack.Last());
                    OperationStack.RemoveAt(OperationStack.Count - 1);
                }
            }
        }

        #endregion
    }
}
