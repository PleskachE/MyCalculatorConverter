
namespace WorkingWithEnteredData.Converters
{
    public class NumbersConverter
    {
        public double StringToDouble(string text)
        {
            double result = 0;
            double.TryParse(text, out result);
            return result;
        }
    }
}
