using Bll.Converters;
using Bll.Model.Abstraction;
using Bll.Model.Common;
using System.Collections.Generic;
using System.Linq;

namespace Bll.Model.PartsAlghoritm
{
    public class OperationHandler : IPartAlgorithm
    {
        #region Fields

        private OperationConverter _operationConverter;
        private List<BaseSymbal> _operationStack;
        private List<BaseSymbal> _listOfReturn;

        #endregion

        #region Ctor

        public OperationHandler(List<BaseSymbal> listOfReturn, List<BaseSymbal> operationStack)
        {
            _operationConverter = new OperationConverter();
            _listOfReturn = listOfReturn;
            _operationStack = operationStack;
        }

        #endregion

        #region Methods

        public void Processing(string symbal)
        {
            var operation = _operationConverter.StringToOperation(symbal);
            if (_operationStack.Count == 0)
            {
                _operationStack.Add(operation);
            }
            else
            {
                var lastOperation = _operationStack.Last();
                if (operation.Priority == Priority.High && lastOperation.Priority == Priority.Low || _operationStack.Last().Value == "(")
                {
                    _operationStack.Add(operation);
                }
                else
                {
                    _listOfReturn.Add(_operationStack.Last());
                    _operationStack.RemoveAt(_operationStack.Count - 1);
                    _operationStack.Add(operation);
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
