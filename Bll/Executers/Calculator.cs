using Bll.Calculator.Converters;
using Bll.Executers.Abstractions;
using Bll.Calculator.Model;
using Bll.Calculator.Model.Abstraction;
using Bll.Calculator.Model.Common;

using System.Collections.Generic;
using System.Linq;

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
            return Result();
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
