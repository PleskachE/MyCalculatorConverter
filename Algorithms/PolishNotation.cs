using Algorithms.Interface;
using Models.Calculator.Abstraction;

namespace Algorithms
{
    public class PolishNotation : IAlgorithm
    {
        #region Fields
        private ICollectionChar _listOfReturn;
        #endregion

        #region Ctor
        public PolishNotation() { Name = "PolishNotation"; }
        #endregion

        #region Property
        public string Name { get; }
        #endregion

        public string Result(ICollectionChar listOfReturn)
        {
            _listOfReturn = listOfReturn;
            string result = "1";           
            return result;
        }
    }
}
