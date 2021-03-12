using Bll.Calculator.AlgorithmHandlers;
using Models.Calculator.Abstraction;
using Models.Calculator.Common;
using Models.Calculator.Entities;

using System.Collections.Generic;
using System.Linq;

namespace Bll.Calculator.Converters
{
    public class PolishAlgorithmConverter
    {
        #region Fields

        private OperationConverter _operationConverter;
        private List<BaseSymbal> _listOfReturn;
        private List<BaseSymbal> _operationStack;

        private PartAlgorithm _symbalHandler;

        #endregion

        #region Ctor

        public PolishAlgorithmConverter()
        {
            _operationConverter = new OperationConverter();
        }

        #endregion

        #region Methods

        public List<BaseSymbal> StringToAlghoritm(string text)
        {
            _listOfReturn = new List<BaseSymbal>();
            _operationStack = new List<BaseSymbal>();
            _listOfReturn.Add(new Number());
            DataProcessing(text);
            return _listOfReturn;
        }

        private void DataProcessing(string text)
        {
            var currentIndex = 0;
            text = CheckingFirstChar(text);
            while (currentIndex < text.Length)
            {
                BaseSymbal symbal = _operationConverter.StringToOperation(text[currentIndex].ToString());
                var priority = symbal.Priority;
                switch (priority)
                {
                    case Priority.Top:
                        if (symbal.Value == "(")
                        {
                            _symbalHandler = new OpenParenthesisHandler(_listOfReturn, _operationStack);
                            GetResultConvert(symbal.Value);
                            _listOfReturn.Add(new Number());
                        }
                        else
                        {
                            _symbalHandler = new ClosingParenthesisHandler(_listOfReturn, _operationStack);
                            GetResultConvert(symbal.Value);
                        }
                        break;
                    case Priority.Minimum:
                        _symbalHandler = new OperandHandler(_listOfReturn, _operationStack);
                        GetResultConvert(symbal.Value);
                        break;
                    case (Priority.Low ):
                        _symbalHandler = new OperationHandler(_listOfReturn, _operationStack);
                        GetResultConvert(symbal.Value);
                        _listOfReturn.Add(new Number());
                        break;
                    case (Priority.High):
                        _symbalHandler = new OperationHandler(_listOfReturn, _operationStack);
                        GetResultConvert(symbal.Value);
                        _listOfReturn.Add(new Number());
                        break;
                }
                currentIndex++;
                if (currentIndex == text.Length && _operationStack.Count != 0)
                {
                    while (_operationStack.Count != 0)
                    {
                        _listOfReturn.Add(_operationStack.Last());
                        _operationStack.RemoveAt(_operationStack.Count - 1);
                    }
                }
            }
        }

        private void GetResultConvert(string symbal)
        {
            _symbalHandler.Processing(symbal);
            _operationStack = _symbalHandler.OperationStack;
            _listOfReturn = _symbalHandler.ListOfReturn;
        }

        private string CheckingFirstChar(string text)
        {
            var symbal = _operationConverter.StringToOperation(text.First().ToString());
            if (symbal.Priority != Priority.Minimum)
            {
                var newText = "0";
                newText += text;
                text = newText;
            }
            return text;
        }

        #endregion
    }
}
