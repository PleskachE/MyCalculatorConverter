using Bll.Converters;
using Bll.Model.Abstraction;

using System.Collections.Generic;

namespace Bll.Model.PartsAlghoritm
{
    public class OpenParenthesisHandler : IPartAlgorithm
    {
        #region Fields

        private OperationConverter _operationConverter;
        private List<BaseSymbal> _operationStack;
        private List<BaseSymbal> _listOfReturn;

        #endregion

        #region Ctor

        public OpenParenthesisHandler(List<BaseSymbal> listOfReturn, List<BaseSymbal> operationStack)
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
            _operationStack.Add(operation);
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
