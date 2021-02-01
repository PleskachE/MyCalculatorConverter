using Bll.Model.Abstraction;
using Bll.Model.Common;

namespace Bll.Model.Operations
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
