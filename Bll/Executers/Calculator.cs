using Bll.CalculatorSupportTools.Converters;
using Bll.Executers.Abstractions;
using Common;
using Models.Calculator.Abstraction;
using Models.Calculator.Common;
using Models.Calculator.Entities;

using System.Collections.Generic;
using System.Linq;
using System;

namespace Bll.Executers
{
    public class Calculator : IExecuter
    {
        #region Fields

        private List<BaseSymbal> _listOfReturn;
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
            _listOfReturn.RemoveAll(x => x.Value == "");
        }

        private string Result()
        {
            string result = "";
            while (_listOfReturn.Count > 2)
            {
                var tempItem = _listOfReturn.First();
                if (tempItem.Priority == Priority.Minimum)
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
                    if (_listOfReturn.Count >= 2)
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
