using Bll.Model.Abstraction;
using Bll.Model.Common;

namespace Bll.Model
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
