using Bll.Converters;
using Bll.Model.Abstraction;

using System.Collections.Generic;
using System.Linq;

namespace Bll.Model.PartsAlghoritm
{
    public class OperandHandler : IPartAlgorithm
    {
        #region Fields

        private OperationConverter _operationConverter;
        private List<BaseSymbal> _operationStack;
        private List<BaseSymbal> _listOfReturn;

        #endregion

        #region Ctor

        public OperandHandler(List<BaseSymbal> listOfReturn, List<BaseSymbal> operationStack)
        {
            _operationConverter = new OperationConverter();
            _listOfReturn = listOfReturn;
            _operationStack = operationStack;
        }

        #endregion

        #region Methods

        public void Processing(string symbal)
        {
            if (_listOfReturn.Last().Priority != Common.Priority.Minimum)
            {
                _listOfReturn.Add(new Number());
                _listOfReturn.Last().Value += (symbal);
            }
            else if(_listOfReturn.Last().Value == "")
            {
                _listOfReturn.Last().Value += (symbal);
            }
            else
            {
                _listOfReturn.Last().Value += (symbal);
            }
        }

        public List<BaseSymbal> GetListOfReturn()
        {
            return _listOfReturn;
        }

        public List<BaseSymbal> GetOperationStack()
        {
            return _operationStack;
        }

        #endregion
    }
}
