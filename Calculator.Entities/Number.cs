using Models.Calculator.Common;
using Models.Calculator.Abstraction;

namespace Models.Calculator.Entities
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
