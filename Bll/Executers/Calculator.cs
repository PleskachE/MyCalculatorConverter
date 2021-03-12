using Bll.CalculatorSupportTools.Converters;
using Bll.Executers.Abstractions;
using Common;
using Models.Calculator.Abstraction;
using Models.Calculator.Entities;

using System;
using Bll.CalculatorSupportTools.Sorters;
using Bll.CalculatorSupportTools.Algorithms;
using Bll.CalculatorSupportTools.Sorters.Interface;
using Bll.CalculatorSupportTools.Algorithms.Interface;

namespace Bll.Executers
{
    public class Calculator : IExecuter
    {
        #region Fields

        private ICollectionChar _listOfReturn;
        private IStackSorter _stackSorter;
        private IAlgorithm _algorithm;
        private string _algorithmName;

        #endregion

        public Calculator(string algorithmName)
        {
            _algorithmName = algorithmName;
        }

        #region Methods

        public string Calculation(string text)
        {
            _listOfReturn = new CollectionChar();
            _listOfReturn = StackConverter.StringToStack(text, _listOfReturn);
            CheckingForNull();
            CreateStackSorter();
            _listOfReturn = _stackSorter.Sort(_listOfReturn);
            CreateAlgorithm();
            var result = Decimal.Parse(_algorithm.Result());
            result = Math.Round(result, Constants.CountOfDecimalPlaces);
            return result.ToString();
        }

        private void CheckingForNull()
        {
            _listOfReturn.Symbals.RemoveAll(x => x.Value == "");
        }

        private void CreateStackSorter()
        {
            switch(_algorithmName)
            {
                case "ReversePolishNotation":
                    _stackSorter = new StackSorterForReversePolishNotation();
                    break;
            }
        }

        private void CreateAlgorithm()
        {
            switch (_algorithmName)
            {
                case "ReversePolishNotation":
                    _algorithm = new ReversePolishNotation(_listOfReturn);
                    break;
            }
        }

        #endregion
    }

}
