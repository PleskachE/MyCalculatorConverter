using Bll.Model.Abstraction;
using Bll.Model.Common;

namespace Bll.Model.Operations
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
