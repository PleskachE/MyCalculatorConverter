using Models.ConverterModels.Abstraction;
using System;
using System.Linq;
using System.Reflection;
using Common;
using System.ComponentModel;

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

            Type type = Type.GetType("BaseUnitSystem");
            var types = GetAssembly().GetTypes().ToList().FindAll(x => x.GetInterface("BaseUnitSystem") != type);
            var res = types.ToList().Find(x => x.GetAttribute<DescriptionAttribute>().Description == text);
            resUnit = (BaseUnitSystem)Activator.CreateInstance(res);
            resUnit.Value = Decimal.Parse(textValue);
            return resUnit;
        }
        private static Assembly GetAssembly()
        {
            string path = @"C:\Users\Sony\source\repos\ReflectionConsole\Animals.Entities\bin\Debug\Animals.Entities.dll";
            var assembly = Assembly.LoadFrom(path);
            return assembly;
        }
    }
}
