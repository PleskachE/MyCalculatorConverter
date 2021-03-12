using Bll.CalculatorSupportTools.Converters;
using Bll.Executers.Abstractions;
using Common;
using Models.Calculator.Abstraction;
using Models.Calculator.Common;
using Models.Calculator.Entities;


using System.Linq;
using System;

namespace Bll.Executers
{
    public class Calculator : IExecuter
    {
        #region Fields

        private ICollectionChar _listOfReturn;
        private PolishAlgorithmConverter _polishAlgorithmConverter;

        #endregion

        #region Ctor

        public Calculator()
        {
            _polishAlgorithmConverter = new PolishAlgorithmConverter();
        }

        #endregion

        #region Methods

        public string Calculation(string text)
        {
            _listOfReturn = _polishAlgorithmConverter.StringToAlghoritm(text);
            CheckingForNull();
            var result = Decimal.Parse(Result());
            result = Math.Round(result, Constants.CountOfDecimalPlaces);
            return result.ToString();
        }

        private void CheckingForNull()
        {
            _listOfReturn
                .Symbals
                .RemoveAll(x => x.Value == "");
        }

        private string Result()
        {
            string result = "";
            while (_listOfReturn.Symbals.Count() > 2)
            {
                var tempItem = _listOfReturn
                    .Symbals
                    .First();
                if (tempItem.Priority == Priority.Minimum)
                {
                    _listOfReturn
                        .Symbals
                        .RemoveAt(0);
                    _listOfReturn
                        .Symbals
                        .Add(tempItem);
                }
                else
                {
                    var tempResult = tempItem
                        .Result(_listOfReturn.Symbals.ElementAt(_listOfReturn.Symbals.Count - 2).Value,
                        _listOfReturn.Symbals.ElementAt(_listOfReturn.Symbals.Count - 1).Value);
                    _listOfReturn
                        .Symbals
                        .Remove(_listOfReturn.Symbals.Last());
                    _listOfReturn
                        .Symbals
                        .Remove(_listOfReturn.Symbals.Last());
                    if (_listOfReturn.Symbals.Count >= 2)
                    {
                        _listOfReturn
                            .Symbals
                            .RemoveAt(0);
                    }
                    _listOfReturn
                        .Symbals
                        .Add(new Number(tempResult));
                }
            }
            result = _listOfReturn
                .Symbals
                .Last().Value;
            return result;
        }

        #endregion
    }

}
