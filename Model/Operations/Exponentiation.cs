using Model.Abstraction;
using Model.Common;
using System;

namespace Model.Operations
{
    public class Exponentiation : BaseSymbal
    {
        public Operation Operation { get; set; }

        public Exponentiation()
        {
            Operation = Operation.Division;
            Priority = Priority.High;
            Value = "^";
        }

        public override string Result(string leftNumber, string rightNumber)
        {
            decimal result = 0;
            decimal _left = 0;
            decimal _right = 0;
            decimal.TryParse(leftNumber, out _left);
            decimal.TryParse(rightNumber, out _right);
            result = (decimal)Math.Pow((double)_left,(double)_right);
            return result.ToString();
        }
    }
}
