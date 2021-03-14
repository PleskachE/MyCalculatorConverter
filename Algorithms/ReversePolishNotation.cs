using Algorithms.Interface;

using Models.Calculator.Abstraction;
using Models.Calculator.Common;
using Models.Calculator.Entities;

using System.Linq;

namespace Algorithms
{
    public class ReversePolishNotation : IAlgorithm
    {
        #region Fields
        private ICollectionChar _listOfReturn;
        #endregion

        #region Ctor
        public ReversePolishNotation() { Name = "ReversePolishNotation"; }
        #endregion

        #region Property
        public string Name { get; }
        #endregion

        public string Result(ICollectionChar listOfReturn)
        {
            _listOfReturn = listOfReturn;
            var stackSorter = new StackSorterForReversePolishNotation();
            _listOfReturn = stackSorter.Sort(_listOfReturn);
            string result = "";
            while (_listOfReturn.Symbals.Count() > 2)
            {
                var tempItem = _listOfReturn.Symbals.First();
                if (tempItem.Priority == Priority.Minimum)
                {
                    _listOfReturn.Symbals.RemoveAt(0);
                    _listOfReturn.Symbals.Add(tempItem);
                }
                else
                {
                    var tempResult = tempItem.Result(_listOfReturn.Symbals.ElementAt(_listOfReturn.Symbals.Count - 2).Value,
                        _listOfReturn.Symbals.ElementAt(_listOfReturn.Symbals.Count - 1).Value);

                    _listOfReturn.Symbals.Remove(_listOfReturn.Symbals.Last());
                    _listOfReturn.Symbals.Remove(_listOfReturn.Symbals.Last());
                    if (_listOfReturn.Symbals.Count >= 2)
                    {
                        _listOfReturn.Symbals.RemoveAt(0);
                    }
                    _listOfReturn.Symbals.Add(new Number(tempResult));
                }
            }
            result = _listOfReturn.Symbals.Last().Value;
            return result;
        }

        private class StackSorterForReversePolishNotation
        {

            private ICollectionChar _stackOfReturn;
            private ICollectionChar _stackWaiting;

            public StackSorterForReversePolishNotation()
            {
                _stackOfReturn = new CollectionChar();
                _stackWaiting = new CollectionChar();
            }

            public ICollectionChar Sort(ICollectionChar stack)
            {
                _stackOfReturn.Symbals.Clear();
                _stackWaiting.Symbals.Clear();
                foreach (var item in stack.Symbals)
                {
                    var priority = item.Priority;
                    switch (priority)
                    {
                        case Priority.Top:
                            if (item.Value == "(")
                            {
                                _stackWaiting.Symbals.Add(item);
                            }
                            else
                            {
                                AddingClosingParenthesis();
                            }
                            break;
                        case Priority.High:
                            if (_stackWaiting.Symbals.Count == 0)
                            {
                                _stackWaiting.Symbals.Add(item);
                            }
                            else if (_stackWaiting.Symbals.Last().Priority == Priority.Low)
                            {
                                _stackWaiting.Symbals.Add(item);
                            }
                            else if (_stackWaiting.Symbals.Last().Value == "(")
                            {
                                _stackWaiting.Symbals.Add(item);
                            }
                            else if (_stackWaiting.Symbals.Last().Priority == item.Priority)
                            {
                                _stackOfReturn.Symbals.Add(_stackWaiting.Symbals.Last());
                                _stackWaiting.Symbals.RemoveAt(_stackWaiting.Symbals.Count - 1);
                                _stackWaiting.Symbals.Add(item);
                            }
                            break;
                        case Priority.Low:
                            if (_stackWaiting.Symbals.Count == 0
                                || _stackWaiting.Symbals.Last().Value == "(")
                            {
                                _stackWaiting.Symbals.Add(item);
                            }
                            else if (_stackWaiting.Symbals.Last().Priority == item.Priority
                                || _stackWaiting.Symbals.Last().Priority == Priority.High)
                            {
                                _stackOfReturn.Symbals.Add(_stackWaiting.Symbals.Last());
                                _stackWaiting.Symbals.RemoveAt(_stackWaiting.Symbals.Count - 1);
                                _stackWaiting.Symbals.Add(item);
                            }
                            break;
                        case Priority.Minimum:
                            _stackOfReturn.Symbals.Add(item);
                            break;
                    }
                }
                if (_stackWaiting.Symbals.Count != 0)
                {
                    while (_stackWaiting.Symbals.Count != 0)
                    {
                        _stackOfReturn.Symbals.Add(_stackWaiting.Symbals.Last());
                        _stackWaiting.Symbals.RemoveAt(_stackWaiting.Symbals.Count - 1);
                    }
                }
                return _stackOfReturn;
            }

            private void AddingClosingParenthesis()
            {
                var newStack = new CollectionChar();
                while (_stackWaiting.Symbals.Last().Value != "(")
                {
                    newStack.Symbals.Insert(0, _stackWaiting.Symbals.Last());
                    _stackWaiting.Symbals.RemoveAt(_stackWaiting.Symbals.Count - 1);
                }
                _stackWaiting.Symbals.RemoveAt(_stackWaiting.Symbals.Count - 1);
                foreach (var op in newStack.Symbals)
                {
                    _stackOfReturn.Symbals.Add(op);
                }
            }
        }

    }
}
