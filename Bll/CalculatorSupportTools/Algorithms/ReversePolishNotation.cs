using Bll.CalculatorSupportTools.Algorithms.Interface;
using Models.Calculator.Abstraction;
using Models.Calculator.Common;
using Models.Calculator.Entities;

using System.Linq;

namespace Bll.CalculatorSupportTools.Algorithms
{
    public class ReversePolishNotation : IAlgorithm
    {
        private ICollectionChar _listOfReturn;

        public ReversePolishNotation(ICollectionChar listOfReturn)
        {
            this._listOfReturn = listOfReturn;
        }

        public string Result()
        {
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
    }
}
