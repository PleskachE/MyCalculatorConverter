using Bll.Calculator.Model.Abstraction;
using Bll.Calculator.Model.Common;

namespace Bll.Calculator.Model
{
    public class Number : BaseSymbal
    {
        public Number() 
        {
            Value = ""; 
            Priority = Priority.Minimum; 
        }

        public Number(string value)
        {
            Value = value;
            Priority = Priority.Minimum;
        }
    }
}
