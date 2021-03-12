using Bll.CalculatorSupportTools.AlgorithmHandlers;
using Models.Calculator.Abstraction;
using Models.Calculator.Common;
using Models.Calculator.Entities;

using System.Collections.Generic;
using System.Linq;

namespace Bll.CalculatorSupportTools.Converters
{
    public class PolishAlgorithmConverter
    {
        #region Fields

        private OperationConverter _operationConverter;
        private ICollectionChar _listOfReturn;
        private ICollectionChar _operationStack;

        private PartAlgorithm _symbalHandler;

        #endregion

        #region Ctor

        public PolishAlgorithmConverter()
        {
            _operationConverter = new OperationConverter();
        }

        #endregion

        #region Methods

        public ICollectionChar StringToAlghoritm(string text)
        {
            _listOfReturn = new CollectionChar();
            _operationStack = new CollectionChar();
            _listOfReturn
                .Symbals
                .Add(new Number());
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
                            _listOfReturn
                                .Symbals
                                .Add(new Number());
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
                        _listOfReturn
                            .Symbals
                            .Add(new Number());
                        break;
                    case (Priority.High):
                        _symbalHandler = new OperationHandler(_listOfReturn, _operationStack);
                        GetResultConvert(symbal.Value);
                        _listOfReturn
                            .Symbals
                            .Add(new Number());
                        break;
                }
                currentIndex++;
                if (currentIndex == text.Length && _operationStack.Symbals.Count != 0)
                {
                    while (_operationStack.Symbals.Count != 0)
                    {
                        _listOfReturn
                            .Symbals
                            .Add(_operationStack.Symbals.Last());
                        _operationStack
                            .Symbals
                            .RemoveAt(_operationStack.Symbals.Count() - 1);
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
