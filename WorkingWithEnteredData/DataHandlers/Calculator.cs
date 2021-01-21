using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingWithEnterdData.Algorithms.Abstraction;
using WorkingWithEnteredData.DataHandlers.Abstractions;

namespace WorkingWithEnteredData.DataHandlers
{
    public class Calculator : InputDataHandler
    {
        #region Fields

        private ICalculationAlgorithm _calculationAlgorithm;

        #endregion

        #region Properties

        private double _result = 0;
        public double Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
            }
        }

        private double _leftNumber = 0;
        public double LeftNumber
        {
            get
            {
                return _leftNumber;
            }
            set
            {
                _leftNumber = value;
            }
        }

        private double _rightNumber = 0;
        public double RightNumber
        {
            get
            {
                return _rightNumber;
            }
            set
            {
                _rightNumber = value;
            }
        }

        #endregion
    }

}
