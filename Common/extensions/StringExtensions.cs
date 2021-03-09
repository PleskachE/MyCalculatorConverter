using System.Linq;

namespace Common.extensions
{
    public static class StringExtensions
    {
        private static char[] numbers = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ',' };
        public static string GetNumbersFromString(this string self)
        {
            string result = "";
            foreach(var item in self.ToCharArray())
            {
                if(numbers.Contains(item) == true)
                {
                    result += item;
                }
            }
            return result;
        }
    }
}
