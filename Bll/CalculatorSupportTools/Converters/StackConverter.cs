using Models.Calculator.Abstraction;
using Models.Calculator.Common;
using Models.Calculator.Entities;

using NLog;

using System.Linq;

namespace Bll.CalculatorSupportTools.Converters
{
    public static class StackConverter
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static ICollectionChar StringToStack(string text, ICollectionChar _listOfReturn)
        {
            if (text.Any())
            {
                var currentIndex = 0;
                text = CheckingFirstChar(text);
                while (currentIndex < text.Length)
                {
                    BaseSymbal symbal = OperationConverter.StringToOperation(text[currentIndex].ToString());
                    _listOfReturn.Symbals.Add(symbal);
                    currentIndex++;
                }
            }
            else
            {
                _logger.Warn("text is empty!");
            }
            return StackFormation(_listOfReturn);
        }

        private static ICollectionChar StackFormation(ICollectionChar _listOfReturn)
        {
            var newlistOfReturn = new CollectionChar();
            while (_listOfReturn.Symbals.Count != 0)
            {
                if (newlistOfReturn.Symbals.Count != 0 
                    &&newlistOfReturn.Symbals.Last().Priority == Priority.Minimum
                    && _listOfReturn.Symbals.First().Priority == Priority.Minimum)
                {
                    newlistOfReturn.Symbals.Last().Value += _listOfReturn.Symbals.First().Value;
                    _listOfReturn.Symbals.RemoveAt(0);
                }
                else
                {
                    newlistOfReturn.Symbals.Add(_listOfReturn.Symbals.First());
                    _listOfReturn.Symbals.RemoveAt(0);
                }
            }
            return newlistOfReturn;
        }

        private static string CheckingFirstChar(string text)
        {
            var symbal = OperationConverter.StringToOperation(text.First().ToString());
            if (symbal.Priority != Priority.Minimum)
            {
                var newText = "0";
                newText += text;
                text = newText;
            }
            return text;
        }
    }
}
