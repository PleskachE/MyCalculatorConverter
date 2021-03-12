
namespace Bll.CalculatorSupportTools.Converters
{
    public static class NumbersConverter
    {
        public static decimal StringToDouble(string text)
        {
            decimal result = 0;
            decimal.TryParse(text, out result);
            return result;
        }
    }
}
