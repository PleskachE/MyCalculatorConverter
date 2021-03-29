using Models.Calculator.Abstraction;
using Models.Calculator.Common;

namespace Models.Calculator.Entities.Operations
{
    public class ClosingParenthesis : BaseSymbal
    {
        public Operation Operation { get; set; }

        public ClosingParenthesis()
        {
            Operation = Operation.ClosingParenthesis;
            Priority = Priority.Top;
            Value = ")";
        }
    }
}
