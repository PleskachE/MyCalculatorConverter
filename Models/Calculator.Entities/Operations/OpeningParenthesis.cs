using Models.Calculator.Abstraction;
using Models.Calculator.Common;

namespace Models.Calculator.Entities.Operations
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
