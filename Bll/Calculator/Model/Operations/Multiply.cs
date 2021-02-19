using Bll.Calculator.Model.Abstraction;
using Bll.Calculator.Model.Common;

namespace Bll.Calculator.Model.Operations
{
    public class Multiply : BaseSymbal
    {
        public Operation Operation { get; set; }

        public Multiply()
        {
            Operation = Operation.Division;
            Priority = Priority.High;
            Value = "*";
        }

        public override string Result(string leftNumber, string rightNumber)
        {
            decimal result = 0;
            decimal _left = 0;
            decimal _right = 0;
            decimal.TryParse(leftNumber, out _left);
            decimal.TryParse(rightNumber, out _right);
            result = (_left * _right);
            return result.ToString();
        }
    }
}
