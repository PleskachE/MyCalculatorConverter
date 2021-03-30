using Models.Calculator.Abstraction;
using Models.Calculator.Common;

using System;
using System.Linq;

namespace Models.Calculator.Entities.Operations
{
    public class SquareRoot : BaseSymbal
    {
        public Operation Operation { get; set; }

        public SquareRoot()
        {
            Operation = Operation.SquareRoot;
            Priority = Priority.High;
            Value = "√";
        }

        public override string Result(string leftNumber, string rightNumber)
        {
            decimal result = 0;
            decimal _left = 2;
            decimal _right = 0;
            decimal.TryParse(rightNumber, out _right);
            if(leftNumber != "0")
            {
                decimal.TryParse(leftNumber, out _left);
            }
            result = (decimal)Math.Pow((double)_right, 1 / (double)_left);
            return result.ToString();
        }
    }
}
