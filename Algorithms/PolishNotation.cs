using System.Linq;

using Algorithms.Common;
using Algorithms.Interface;

using Models.Calculator.Abstraction;
using Models.Calculator.Common;
using Models.Calculator.Entities;

namespace Algorithms
{
    public class PolishNotation : IAlgorithm
    {
        #region Fields

        private ICollectionChar _listOfReturn;
        private IStackSorter _stackSorter;

        #endregion

        #region Ctor

        public PolishNotation() { Name = "PolishNotation"; }

        #endregion

        #region Property

        public string Name { get; }

        #endregion

        #region PublickMethods

        public string Result(ICollectionChar listOfReturn)
        {
            _listOfReturn = listOfReturn;
            _stackSorter = new StackSorterPolishNotation();
            _listOfReturn = _stackSorter.Sort(_listOfReturn);
            string result = "0";
            while (_listOfReturn.Symbals.Count > 2)
            {
                var tempItem = _listOfReturn.Symbals.First();
                if(_listOfReturn.Symbals.First().Priority != Priority.Minimum)
                {
                    MovesFirstItemToLastPlaceInStack(); 
                }
                else
                {
                    if(CheckingNoteReadyForExecution() == true)
                    {
                        AddResultToStack(CreateResult(_listOfReturn.Symbals.ElementAt(2)));
                    }
                    else
                    {
                        MovesFirstItemToLastPlaceInStack();
                    }
                }
            }
            result = _listOfReturn.Symbals.Last().Value;
            return result;
        }

        #endregion

        #region PrivateMethods

        private void AddResultToStack(string result)
        {
            _listOfReturn.Symbals.RemoveRange(0, 3);
            _listOfReturn.Symbals.Add(new Number(result));
        }

        private void MovesFirstItemToLastPlaceInStack()
        {
            var tempItem = _listOfReturn.Symbals.First();
            _listOfReturn.Symbals.RemoveAt(0);
            _listOfReturn.Symbals.Add(tempItem);
        }

        private string CreateResult(BaseSymbal item)
        {
            return item.Result(GetLeftItem(), GetRightItem());
        }

        private string GetLeftItem()
        {
            return _listOfReturn.Symbals.First().Value;
        }

        private string GetRightItem()
        {
            return _listOfReturn.Symbals.ElementAt(1).Value;
        }

        private bool CheckingNoteReadyForExecution()
        {
            bool result = false;
            if((_listOfReturn.Symbals.ElementAt(1).Priority == Priority.Minimum)&
                (_listOfReturn.Symbals.ElementAt(2).Priority != Priority.Minimum))
            {
                result = true;
            }
            return result;
        }

        #endregion
    }
}
