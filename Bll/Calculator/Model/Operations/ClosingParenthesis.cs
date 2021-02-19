using Bll.Calculator.Model.Abstraction;
using Bll.Calculator.Model.Common;

namespace Bll.Calculator.Model.Operations
{
    public class ClosingParenthesis : BaseSymbal
    {
        public Operation Operation { get; set; }

        public ClosingParenthesis()
        {
            Operation = Operation.Division;
            Priority = Priority.Top;
            Value = ")";
        }
    }
}
