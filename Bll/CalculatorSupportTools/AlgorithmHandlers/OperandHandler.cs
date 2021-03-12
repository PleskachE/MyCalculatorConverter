using Models.Calculator.Abstraction;
using Models.Calculator.Entities;
using Models.Calculator.Common;

using System.Linq;

namespace Bll.CalculatorSupportTools.AlgorithmHandlers
{
    public class OperandHandler : PartAlgorithm
    {

        #region Ctor

        public OperandHandler(ICollectionChar listOfReturn, ICollectionChar operationStack)
        {
            OperationStack = operationStack;
            ListOfReturn = listOfReturn;
        }

        #endregion

        #region Methods

        public override void Processing(string symbal)
        {
            if (ListOfReturn.Symbals.Last().Priority != Priority.Minimum)
            {
                ListOfReturn
                    .Symbals
                    .Add(new Number());
                ListOfReturn
                    .Symbals
                    .Last()
                    .Value += (symbal);
            }
            else
            {
                ListOfReturn
                    .Symbals
                    .Last()
                    .Value += (symbal);
            }
        }

        #endregion
    }
}
