using ConverterModels.Abstraction;
using ConverterModels.Entities.Units;
using System;
using System.Linq;

namespace Bll.ValueConverters
{
    public static class UnitsParser
    {
        private static BaseUnitSystem[] _units = new BaseUnitSystem[2];

        public static void Parse(string text)
        {
            var firstElem = text.Substring(0, text.LastIndexOf("="));
            var lastElem = text.Substring(text.LastIndexOf("=") + 2, (text.Count()- firstElem.Count() - 1));
            _units[0] = CreatingNewUnit(firstElem);
            _units[1] = CreatingNewUnit(lastElem);
        }

        public static BaseUnitSystem GetFirstUnit() { return _units[0]; }
        public static BaseUnitSystem GetLastUnit() { return _units[1]; }

        private static BaseUnitSystem CreatingNewUnit(string text)
        {
            char[] numbers = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            var textValue = text.Intersect(numbers).ToString();
            text.Remove(textValue.Length);
            BaseUnitSystem resUnit = null;
            switch (text)
            {
                case "Millimeter":
                    resUnit = new Millimeter(Decimal.Parse(textValue));
                    break;
                case "Centimeter":
                    resUnit = new Centimeter(Decimal.Parse(textValue));
                    break;
                case "Decimeter":
                    resUnit = new Decimeter(Decimal.Parse(textValue));
                    break;
                case "Metre":
                    resUnit = new Metre(Decimal.Parse(textValue));
                    break;
                case "Kilometer":
                    resUnit = new Kilometer(Decimal.Parse(textValue));
                    break;
                case "Inch":
                    resUnit = new Inch(Decimal.Parse(textValue));
                    break;
                case "Ft":
                    resUnit = new Ft(Decimal.Parse(textValue));
                    break;
                case "Yard":
                    resUnit = new Yard(Decimal.Parse(textValue));
                    break;
                case "Mile":
                    resUnit = new Mile(Decimal.Parse(textValue));
                    break;
            }
            return resUnit;
        }
    }
}
