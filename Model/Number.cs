using Model.Abstraction;
using Model.Common;

namespace Model
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
