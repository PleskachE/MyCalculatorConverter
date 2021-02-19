
namespace Bll.Calculator.Converters
{
    public class NumbersConverter
    {
        public decimal StringToDouble(string text)
        {
            decimal result = 0;
            decimal.TryParse(text, out result);
            return result;
        }
    }
}
