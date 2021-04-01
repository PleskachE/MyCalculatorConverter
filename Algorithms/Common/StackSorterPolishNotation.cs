using Models.Calculator.Abstraction;
using Models.Calculator.Common;
using Models.Calculator.Entities;

using System.Linq;

namespace Algorithms.Common
{
    internal sealed class StackSorterPolishNotation : IStackSorter
    {
        #region Fields

        private ICollectionChar _stackOfReturn;
        private ICollectionChar _stackWaiting;

        #endregion

        #region Ctor

        public StackSorterPolishNotation()
        {
            _stackOfReturn = new CollectionChar();
            _stackWaiting = new CollectionChar();
        }

        #endregion

        #region PublicMethods

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
                            AddToStackWaiting(item);
                        }
                        else
                        {
                            AddClosingParenthesis();
                        }
                        break;

                    case Priority.High:
                        if (AccessAddItemToWaitingStack() || _stackWaiting.Symbals.Last().Priority == Priority.Low)
                        {
                            AddToStackWaiting(item);
                        }
                        else if (AccessAddItemToReturnStack(item.Priority))
                        {
                            AddToStackReturn(_stackWaiting.Symbals.Last());
                            DeleteLastItemToStack(_stackWaiting);
                            AddToStackWaiting(item);
                        }
                        break;

                    case Priority.Low:
                        if (AccessAddItemToWaitingStack())
                        {
                            AddToStackWaiting(item);
                        }
                        else if (AccessAddItemToReturnStack(item.Priority) || AccessAddItemToReturnStack(Priority.High))
                        {
                            AddToStackReturn(_stackWaiting.Symbals.Last());
                            DeleteLastItemToStack(_stackWaiting);
                            AddToStackWaiting(item);
                        }
                        break;

                    case Priority.Minimum:
                        AddToStackReturn(item);
                        break;
                }
            }
            if (_stackWaiting.Symbals.Count != 0)
            {
                while (_stackWaiting.Symbals.Count != 0)
                {
                    AddToStackReturn(_stackWaiting.Symbals.Last());
                    DeleteLastItemToStack(_stackWaiting);
                }
            }
            return _stackOfReturn;
        }

        #endregion

        #region PrivateMethods

        private bool AccessAddItemToReturnStack(Priority priority)
        {
            bool result = false;
            if (_stackWaiting.Symbals.Last().Priority == priority) { result = true; }
            return result;
        }

        private bool AccessAddItemToWaitingStack()
        {
            bool result = false;
            if(_stackWaiting.Symbals.Count == 0) { result = true; }
            else if(_stackWaiting.Symbals.Last().Value == "(") { result = true; }
            return result;
        }

        private void DeleteLastItemToStack(ICollectionChar stack)
        {
            stack.Symbals.RemoveAt(stack.Symbals.Count - 1);
        }

        private void AddToStackReturn(BaseSymbal item)
        {
            _stackOfReturn.Symbals.Add(item);
        }

        private void AddToStackWaiting(BaseSymbal item)
        {
            _stackWaiting.Symbals.Add(item);
        }

        private void AddClosingParenthesis()
        {
            var newStack = new CollectionChar();
            while (_stackWaiting.Symbals.Last().Value != "(")
            {
                newStack.Symbals.Insert(0, _stackWaiting.Symbals.Last());
                DeleteLastItemToStack(_stackWaiting);
            }
            DeleteLastItemToStack(_stackWaiting);
            foreach (var op in newStack.Symbals)
            {
                AddToStackReturn(op);
            }
        }

        #endregion
    }
}

