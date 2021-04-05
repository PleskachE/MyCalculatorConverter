using Bll.CalculatorSupportTools.Converters;
using Bll.Executers.Abstractions;

using Common;

using Models.Calculator.Abstraction;
using Models.Calculator.Entities;

using System;

using Algorithms.Interface;

using NLog;

namespace Bll.Executers
{
    public class Calculator : IExecuter
    {
        #region Fields

        private ICollectionChar _listOfReturn;
        private IAlgorithm _algorithm;
        private Logger _logger;

        #endregion

        public Calculator(IAlgorithm algorithm)
        {
            _algorithm = algorithm;
            _logger = LogManager.GetCurrentClassLogger();
        }

        #region Methods

        public string Calculation(string text)
        {
            decimal result = 0;
            if (text != null)
            {
                _listOfReturn = new CollectionChar();
                _listOfReturn = StackConverter.StringToStack(text, _listOfReturn);
                CheckingForNull();
                result = Decimal.Parse(_algorithm.Result(_listOfReturn));
                result = Math.Round(result, Constants.CountOfDecimalPlaces);
            }
            else
            {
                _logger.Warn("text is null");
            }
            return result.ToString();
        }

        private void CheckingForNull()
        {
            try
            {
                _listOfReturn.Symbals.RemoveAll(x => x.Value == "");
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
            }
        }

        #endregion
    }

}
