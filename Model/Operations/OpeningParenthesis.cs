using Model.Abstraction;
using Model.Common;

namespace Model.Operations
{
    public class OpeningParenthesis : BaseOperation
    {
        public Operation Operation { get; set; }

        public OpeningParenthesis()
        {
            Operation = Operation.Division;
            Priority = Priority.High;
            Value = "(";
        }
    }
}
