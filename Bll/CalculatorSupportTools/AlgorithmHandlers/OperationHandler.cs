using Bll.CalculatorSupportTools.Converters;
using Models.Calculator.Abstraction;
using Models.Calculator.Common;

using System.Linq;

namespace Bll.CalculatorSupportTools.AlgorithmHandlers
{
    public class OperationHandler : PartAlgorithm
    {
        #region Fields
        private OperationConverter _operationConverter = new OperationConverter();
        #endregion

        #region Ctor
        public OperationHandler(ICollectionChar listOfReturn, ICollectionChar operationStack)
        {
            OperationStack = operationStack;
            ListOfReturn = listOfReturn;
        }
        #endregion

        #region Methods
        public override void Processing(string symbal)
        {
            var operation = _operationConverter.StringToOperation(symbal);
            if (OperationStack.Symbals.Count() == 0)
            {
                OperationStack
                    .Symbals
                    .Add(operation);
            }
            else
            {
                var lastOperation = OperationStack
                    .Symbals
                    .Last();
                if (operation.Priority == Priority.High 
                    && lastOperation.Priority == Priority.Low 
                    || OperationStack.Symbals.Last().Value == "(")
                {
                    OperationStack
                        .Symbals
                        .Add(operation);
                }
                else
                {
                    ListOfReturn
                        .Symbals
                        .Add(OperationStack.Symbals.Last());
                    OperationStack
                        .Symbals
                        .RemoveAt(OperationStack.Symbals.Count - 1);
                    OperationStack
                        .Symbals
                        .Add(operation);
                }
            }
        }
        #endregion
    }
}
