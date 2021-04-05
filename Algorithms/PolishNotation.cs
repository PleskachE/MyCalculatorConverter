using System;
using System.Linq;

using Algorithms.Common;
using Algorithms.Interface;

using Models.Calculator.Abstraction;
using Models.Calculator.Common;
using Models.Calculator.Entities;

using NLog;

namespace Algorithms
{
    public class PolishNotation : IAlgorithm
    {
        #region Fields

        private ICollectionChar _listOfReturn;
        private IStackSorter _stackSorter;
        private Logger _logger;

        #endregion

        #region Ctor

        public PolishNotation() 
        {
            Name = "PolishNotation";
            _logger = LogManager.GetCurrentClassLogger();
        }

        #endregion

        #region Property

        public string Name { get; }

        #endregion

        #region PublickMethods

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
                    if (_listOfReturn.Symbals.First().Priority != Priority.Minimum)
                    {
                        MovesFirstItemToLastPlaceInStack();
                    }
                    else
                    {
                        if (CheckingNoteReadyForExecution() == true)
                        {
                            AddResultToStack(CreateResult(_listOfReturn.Symbals.ElementAt(2)));
                        }
                        else
                        {
                            MovesFirstItemToLastPlaceInStack();
                        }
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
            if (result == null)
            {
                result = "0";
            }
            _listOfReturn.Symbals.RemoveRange(0, 3);
            _listOfReturn.Symbals.Add(new Number(result));
        }

        private void MovesFirstItemToLastPlaceInStack()
        {
            try
            {
                var tempItem = _listOfReturn.Symbals.First();
                _listOfReturn.Symbals.RemoveAt(0);
                _listOfReturn.Symbals.Add(tempItem);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
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
            return item.Result(GetLeftItem(), GetRightItem());
        }

        private string GetLeftItem()
        {
            string result = null;
            try
            {
                result = _listOfReturn.Symbals.First().Value;
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
                result = _listOfReturn.Symbals.ElementAt(1).Value;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                result = "0";
            }
            return result;
        }

        private bool CheckingNoteReadyForExecution()
        {
            bool result = false;
            if((_listOfReturn.Symbals.ElementAt(1).Priority == Priority.Minimum)&
                (_listOfReturn.Symbals.ElementAt(2).Priority != Priority.Minimum))
            {
                result = true;
            }
            return result;
        }

        #endregion
    }
}
