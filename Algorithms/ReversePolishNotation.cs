using Algorithms.Common;
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
        private IStackSorter _stackSorter;

        #endregion

        #region Ctor

        public ReversePolishNotation() 
        {
            Name = "ReversePolishNotation";
        }

        #endregion

        #region Property

        public string Name { get; }

        #endregion

        #region PublicMethods

        public string Result(ICollectionChar listOfReturn)
        {
            _listOfReturn = listOfReturn;
            _stackSorter = new StackSorterPolishNotation();
            _listOfReturn = _stackSorter.Sort(_listOfReturn);
            string result = "0";
            while (_listOfReturn.Symbals.Count > 2)
            {
                var tempItem = _listOfReturn.Symbals.First();
                if (tempItem.Priority == Priority.Minimum)
                {
                    listOfReturn = MovesFirstItemToLastPlaceInStack(_listOfReturn, tempItem);
                }
                else
                {
                    AddResultToStack(CreateResult(tempItem));
                }
            }
            result = _listOfReturn.Symbals.Last().Value;
            return result;
        }

        #endregion

        #region PrivateMethods

        private void AddResultToStack(string result)
        {
            _listOfReturn.Symbals.Remove(_listOfReturn.Symbals.Last());
            _listOfReturn.Symbals.Remove(_listOfReturn.Symbals.Last());
            if (_listOfReturn.Symbals.Count >= 2)
            {
                _listOfReturn.Symbals.RemoveAt(0);
            }
            _listOfReturn.Symbals.Add(new Number(result));
        }

        private ICollectionChar MovesFirstItemToLastPlaceInStack(ICollectionChar listOfReturn, BaseSymbal item)
        {
            listOfReturn.Symbals.RemoveAt(0);
            _listOfReturn.Symbals.Add(item);
            return listOfReturn;
        }

        private string CreateResult(BaseSymbal item)
        {
            return item.Result(GetLeftItem(), GetRightItem());
        }

        private string GetLeftItem()
        {
            return _listOfReturn.Symbals.ElementAt(_listOfReturn.Symbals.Count - 2).Value;
        }

        private string GetRightItem()
        {
            return _listOfReturn.Symbals.ElementAt(_listOfReturn.Symbals.Count - 1).Value;
        }

        #endregion
    }
}
