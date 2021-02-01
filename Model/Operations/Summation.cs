using Model.Abstraction;
using Model.Common;

namespace Model.Operations
{
    public class Summation : BaseSymbal
    {
        public Operation Operation { get; set; }

        public Summation()
        {
            Operation = Operation.Division;
            Priority = Priority.High;
            Value = "+";
        }

        public override string Result(string leftNumber, string rightNumber)
        {
            decimal result = 0;
            decimal _left = 0;
            decimal _right = 0;
            decimal.TryParse(leftNumber, out _left);
            decimal.TryParse(rightNumber, out _right);
            result = (_left + _right);
            return result.ToString();
        }
    }
}
