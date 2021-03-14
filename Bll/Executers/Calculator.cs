using Bll.CalculatorSupportTools.Converters;
using Bll.Executers.Abstractions;

using Common;

using Models.Calculator.Abstraction;
using Models.Calculator.Entities;

using System;

using Algorithms.Interface;

namespace Bll.Executers
{
    public class Calculator : IExecuter
    {
        #region Fields

        private ICollectionChar _listOfReturn;
        private IAlgorithm _algorithm;

        #endregion

        public Calculator(IAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }

        #region Methods

        public string Calculation(string text)
        {
            _listOfReturn = new CollectionChar();
            _listOfReturn = StackConverter.StringToStack(text, _listOfReturn);
            CheckingForNull();
            var result = Decimal.Parse(_algorithm.Result(_listOfReturn));
            result = Math.Round(result, Constants.CountOfDecimalPlaces);
            return result.ToString();
        }

        private void CheckingForNull()
        {
            _listOfReturn.Symbals.RemoveAll(x => x.Value == "");
        }

        #endregion
    }

}
