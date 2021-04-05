using Algorithms.Common;
using Algorithms.Interface;

using Models.Calculator.Abstraction;
using Models.Calculator.Common;
using Models.Calculator.Entities;

using NLog;

using System;
using System.Linq;

namespace Algorithms
{
    public class ReversePolishNotation : IAlgorithm
    {
        #region Fields

        private ICollectionChar _listOfReturn;
        private IStackSorter _stackSorter;
        private Logger _logger;

        #endregion

        #region Ctor

        public ReversePolishNotation() 
        {
            Name = "ReversePolishNotation";
            _logger = LogManager.GetCurrentClassLogger();
        }

        #endregion

        #region Property

        public string Name { get; }

        #endregion

        #region PublicMethods

        public string Result(ICollectionChar listOfReturn)
        {
            string result = "0";
            if (listOfReturn != null)
            {
                _listOfReturn = listOfReturn;
                _stackSorter = new StackSorterPolishNotation();
                _listOfReturn = _stackSorter.Sort(_listOfReturn);
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
            }
            else
            {
                _logger.Warn("ICollectionChar is null");
            }
            return result;
        }

        #endregion

        #region PrivateMethods

        private void AddResultToStack(string result)
        {
            if(result == null)
            {
                result = "0";
            }
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
            try
            {
                listOfReturn.Symbals.RemoveAt(0);
                _listOfReturn.Symbals.Add(item);
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
            }
            return listOfReturn;
        }

        private string CreateResult(BaseSymbal item)
        {
            string result = null;
            try
            {
                result = item.Result(GetLeftItem(), GetRightItem());
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                result = "0";
            }
            return result;
        }

        private string GetLeftItem()
        {
            string result = null;
            try
            {
                result = _listOfReturn.Symbals.ElementAt(_listOfReturn.Symbals.Count - 2).Value;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                result = "0";
            }
            return result;
        }

        private string GetRightItem()
        {
            string result = null;
            try
            {
                result = _listOfReturn.Symbals.ElementAt(_listOfReturn.Symbals.Count - 1).Value;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                result = "0";
            }
            return result;
        }

        #endregion
    }
}
