using Model.Abstraction;

namespace Model
{
    public class Number : BaseOperation
    {

        public Number() { Value = ""; }

        public Number(string value)
        {
            Value = value;
        }
    }
}
