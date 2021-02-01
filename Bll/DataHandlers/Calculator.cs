using Bll.Converters;
using Bll.DataHandlers.Abstractions;
using Bll.Model;
using Bll.Model.Abstraction;
using Bll.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bll.DataHandlers
{
    public class Calculator : InputDataHandler
    {
        #region Fields

        private OperationConverter _operationConverter;
        private readonly List<string> _operations = new List<string> { "+", "-", "*", "/", "^" };
        private List<BaseSymbal> _listOfReturn;
        private List<BaseSymbal> _operationStack;

        #endregion

        #region Ctor

        public Calculator()
        {
            _operationConverter = new OperationConverter();
        }

        #endregion

        #region Methods

        public string Calculation(string text)
        {
            _listOfReturn = new List<BaseSymbal>();
            _operationStack = new List<BaseSymbal>();
            _listOfReturn.Add(new Number());
            DataProcessing(text);
            return Result();
        }

        private void DataProcessing(string text)
        {
            var currentIndex = 0;

            while (currentIndex < text.Length)
            {
                if (text[currentIndex].ToString() == "(")
                {
                    var operation = _operationConverter.StringToOperation(text[currentIndex].ToString());
                    _operationStack.Add(operation);
                }
                else if (text[currentIndex].ToString() == ")")
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
                else if (_operations.Contains(text[currentIndex].ToString()) == false)
                {
                    if ()
                    {
                        _listOfReturn.Add(new Number());
                        _listOfReturn.Last().Value += (text[currentIndex].ToString());
                    }
                    else
                    {
                        _listOfReturn.Last().Value += (text[currentIndex].ToString());
                    }
                }
                else
                {
                    var operation = _operationConverter.StringToOperation(text[currentIndex].ToString());
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
                currentIndex++;
                if (currentIndex == text.Length && _operationStack.Count != 0)
                {
                    _listOfReturn.Add(_operationStack.Last());
                    _operationStack.RemoveAt(_operationStack.Count - 1);
                }
            }
        }

        private string Result()
        {
            string result = "";
            while (_listOfReturn.Count > 1)
            {
                var tempItem = _listOfReturn.First();
                if (_listOfReturn.First().Value == "")
                {
                    _listOfReturn.RemoveAt(0);
                }
                else if (_operations.Contains(tempItem.Value) == false)
                {
                    _listOfReturn.RemoveAt(0);
                    _listOfReturn.Add(tempItem);
                }
                else
                {
                    var tempResult = tempItem.Result(_listOfReturn.ElementAt(_listOfReturn.Count - 2).Value,
                        _listOfReturn.ElementAt(_listOfReturn.Count - 1).Value);
                    _listOfReturn.Remove(_listOfReturn.Last());
                    _listOfReturn.Remove(_listOfReturn.Last());
                    if (_listOfReturn.Count >= 3)
                    {
                        _listOfReturn.RemoveAt(0);
                    }
                    _listOfReturn.Add(new Number(tempResult));
                }
            }
            result = _listOfReturn.Last().Value;
            return result;
        }

        #endregion
    }

}
