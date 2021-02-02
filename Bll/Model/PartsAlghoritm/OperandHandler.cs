using Bll.Model.Abstraction;

using System.Collections.Generic;
using System.Linq;

namespace Bll.Model.PartsAlghoritm
{
    public class OperandHandler : PartAlgorithm
    {

        #region Ctor

        public OperandHandler(List<BaseSymbal> listOfReturn, List<BaseSymbal> operationStack)
        {
            OperationStack = operationStack;
            ListOfReturn = listOfReturn;
        }

        #endregion

        #region Methods

        public override void Processing(string symbal)
        {
            if (ListOfReturn.Last().Priority != Common.Priority.Minimum)
            {
                ListOfReturn.Add(new Number());
                ListOfReturn.Last().Value += (symbal);
            }
            else if(ListOfReturn.Last().Value == "")
            {
                ListOfReturn.Last().Value += (symbal);
            }
            else
            {
                ListOfReturn.Last().Value += (symbal);
            }
        }

        #endregion
    }
}
