using Bll.Converters;
using Bll.Model.Abstraction;

using System.Collections.Generic;
using System.Linq;

namespace Bll.Model.PartsAlghoritm
{
    public class ClosingParenthesisHandler : IPartAlgorithm
    {
        #region Fields

        private OperationConverter _operationConverter;
        private List<BaseSymbal> _operationStack;
        private List<BaseSymbal> _listOfReturn;

        #endregion

        #region Ctor

        public ClosingParenthesisHandler(List<BaseSymbal> listOfReturn, List<BaseSymbal> operationStack)
        {
            _operationConverter = new OperationConverter();
            _listOfReturn = listOfReturn;
            _operationStack = operationStack;
        }

        #endregion

        #region Methods

        public void Processing(string symbal)
        {
            while (_operationStack.Count != 0)
            {
                if (_operationStack.Last().Value == "(" || _operationStack.Last().Value == ")")
                {
                    _operationStack.Remove(_operationStack.Last());
                }
                else
                {
                    _listOfReturn.Add(_operationStack.Last());
                    _operationStack.RemoveAt(_operationStack.Count - 1);
                }
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
