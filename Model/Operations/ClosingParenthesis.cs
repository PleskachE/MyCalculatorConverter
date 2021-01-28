using Model.Abstraction;
using Model.Common;

namespace Model.Operations
{
    public class ClosingParenthesis : BaseOperation
    {
        public Operation Operation { get; set; }

        public ClosingParenthesis()
        {
            Operation = Operation.Division;
            Priority = Priority.High;
            Value = ")";
        }
    }
}
