using Bll.Calculator.Model.Abstraction;
using Bll.Calculator.Model.Common;

namespace Bll.Calculator.Model.Operations
{
    public class OpeningParenthesis : BaseSymbal
    {
        public Operation Operation { get; set; }

        public OpeningParenthesis()
        {
            Operation = Operation.Division;
            Priority = Priority.Top;
            Value = "(";
        }
    }
}
