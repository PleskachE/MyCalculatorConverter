using Common.extensions;

using Models.ConverterNumber.Entity;

using NLog;

using NumberSystemConverter.abstraction;

using System;
using System.Linq;
using System.Text;

namespace NumberSystemConverter
{
    public class DecimalToBinaryConverter : INumberConverter
    {
        #region Fields

        private Logger _logger;
        private delegate string Converter(Number number);
        private readonly char _floatingPoint = ',';
        private readonly int _maximumNumberDecimalPlaces = 9;

        #endregion

        #region Ctor

        public DecimalToBinaryConverter() { _logger = LogManager.GetCurrentClassLogger(); }

        #endregion

        #region PublickMethod

        public string Conversion(string text)
        {
            text = text.GetNumbersFromString();
            var number = new Number(text);
            Converter converter = DefiningExecutingMethod(number);
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append(converter(number));
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                sb.Append("0");
            }
            _logger.Info(text + " = " + sb.ToString());
            return sb.ToString();
        }

        #endregion

        #region PrivateMethods

        private Converter DefiningExecutingMethod(Number number)
        {
            Converter converter = null;
            if (number.Value.ToString().Contains(_floatingPoint) == true)
            {
                var arr = number.Value.ToString().Split(_floatingPoint);
                if(arr[0] == "0")
                {
                    converter = ConvertingFractionsLessThanOne;
                }
                else
                {
                    converter = ConvertingFractionsMoreThanOne;
                }
            }
            else
            {
                converter = ConvertingIntegers;
            }
            return converter;
        }

        private string ConvertingFractionsMoreThanOne(Number number)
        {
            var arr = number.Value.ToString().Split(',');
            if(arr.Length>2)
            {
                _logger.Warn("Extra floating points in the text!");
            }
            var part1 = ConvertingIntegers(new Number(arr[0]));
            var part2 = ConvertingFractionsLessThanOne(new Number("0," + arr[1]));
            var templist = part2.ToList();
            templist.RemoveRange(0, 2);
            part2 = new string(templist.ToArray());
            return part1 + "." + part2;
        }

        private string ConvertingFractionsLessThanOne(Number number)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            do
            {
                number.Value *= 2;
                var newNumber = (int)number.Value;
                if (newNumber >= 1)
                {
                    sb.Append("1");
                    number.Value -= newNumber;
                }
                else
                {
                    sb.Append("0");
                }
                count++;
            }
            while ((number.Value < 2) & (count <= _maximumNumberDecimalPlaces));
            return "0," + sb.ToString();
        }

        private string ConvertingIntegers(Number number)
        {
            StringBuilder sb = new StringBuilder();
            do
            {
                if ((number.Value % 2) == 0)
                {
                    sb.Append("0");
                }
                else
                {
                    sb.Append("1");
                }
                number.Value /= 2;
            }
            while (number.Value >= 1);
            return new string(sb.ToString().Reverse().ToArray());
        }

        #endregion
    }
}
