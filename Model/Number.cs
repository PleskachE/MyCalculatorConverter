using Model.Abstraction;

namespace Model
{
    public class Number : BaseSymbal
    {

        public Number() { Value = ""; }

        public Number(string value)
        {
            Value = value;
        }
    }
}
