using Models.Calculator.Abstraction;

using System.Linq;

namespace Bll.CalculatorSupportTools.AlgorithmHandlers
{
    public class ClosingParenthesisHandler : PartAlgorithm
    {

        #region Ctor

        public ClosingParenthesisHandler(ICollectionChar listOfReturn, ICollectionChar operationStack)
        {
            ListOfReturn = listOfReturn;
            OperationStack = operationStack;
        }

        #endregion

        #region Methods

        public override void Processing(string symbal)
        {
            while (OperationStack.Symbals.Count != 0)
            {
                if (OperationStack.Symbals.Last().Value == "(" || OperationStack.Symbals.Last().Value == ")")
                {
                    OperationStack
                        .Symbals
                        .Remove(OperationStack.Symbals.Last());
                }
                else
                {
                    ListOfReturn
                        .Symbals
                        .Add(OperationStack.Symbals.Last());
                    OperationStack
                        .Symbals
                        .RemoveAt(OperationStack.Symbals.Count - 1);
                }
            }
        }

        #endregion
    }
}
