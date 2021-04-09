using Common.extensions;

using Models.ConverterNumber.Entity;

using NLog;

using NumberSystemConverter.abstraction;

using System;
using System.Linq;
using System.Text;

namespace NumberSystemConverter
{
    public class BinaryToDecimalConverter : INumberConverter
    {
        #region Fields

        private Logger _logger;
        private delegate string Converter(Number number);
        private readonly char _floatingPoint = ',';

        #endregion

        #region Ctor

        public BinaryToDecimalConverter() { _logger = LogManager.GetCurrentClassLogger(); }

        #endregion

        #region Properties

        public string Name { get; } = "Binary To Decimal";

        #endregion

        #region PublicMethod

        public string Conversion(string text)
        {
            text = text.GetBinaryNumbersFromString();
            StringBuilder sb = new StringBuilder();
            var number = new Number(text);
            Converter converter = DefiningExecutingMethod(number);
            try
            {
                sb.Append(converter(number));
            }
            catch (Exception ex)
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
            var isChecked = number.Value.ToString().Contains(_floatingPoint);
            switch(isChecked)
            {
                case true:
                    converter = ConvertingFractions;
                    break;
                case false:
                    converter = ConvertingIntegers;
                    break;
            }
            return converter;
        }

        private string ConvertingFractions(Number number)
        {
            string result = "";
            var parts = number.Value.ToString().Split(_floatingPoint);
            var power = parts[0].Length - 1;
            var units = number.Value.ToString().Replace(_floatingPoint.ToString(), "").ToCharArray();
            foreach (var item in units)
            {
                var tempResult = Double.Parse(item.ToString()) * (Math.Pow(2, power));
                if (result == "")
                {
                    result = tempResult.ToString();
                }
                else
                {
                    result = (Double.Parse(result) + tempResult).ToString();
                }
                power--;
            }
            return result;
        }

        private string ConvertingIntegers(Number number)
        {
            string result = "";
            var units = number.Value.ToString().ToCharArray();
            var power = units.Length - 1;
            foreach (var item in units)
            {
                var tempResult = Double.Parse(item.ToString()) * (Math.Pow(2, power));
                if(result == "")
                {
                    result = tempResult.ToString();
                }
                else
                {
                    result = (Double.Parse(result) + tempResult).ToString();
                }
                power--;
            }
            return result;
        }

        #endregion
    }
}
