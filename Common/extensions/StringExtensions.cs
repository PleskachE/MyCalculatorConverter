using System.Linq;

namespace Common.extensions
{
    public static class StringExtensions
    {
        private readonly static char[] numbers = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ',' };
        private readonly static char[] binaryNumbers = new char[] { '1', '0', ',' };
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
            if(result == "")
            {
                result = "0";
            }
            return result;
        }

        public static string GetBinaryNumbersFromString(this string self)
        {
            string result = "";
            foreach (var item in self.ToCharArray())
            {
                if (binaryNumbers.Contains(item) == true)
                {
                    result += item;
                }
            }
            if (result == "")
            {
                result = "0";
            }
            return result;
        }
    }
}
