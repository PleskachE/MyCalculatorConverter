using System;
using System.Windows;

namespace MyCalculatorConverter.Converters
{
    public static class NumbersConverter
    {
        public static double StringToDoubleConvert(string text)
        {
            double result = 0;
            try
            {
                result = Double.Parse(text);
            }
            catch
            {
                MessageBox.Show("Что то ввелось не так");
            }
            return result;
        }

        public static string DoubleToStringConvert(double value)
        {
            string result = "";
            try
            {
                result = value.ToString();
            }
            catch
            {
                MessageBox.Show("Что то ввелось не так");
            }
            return result;
        }
    }
}
