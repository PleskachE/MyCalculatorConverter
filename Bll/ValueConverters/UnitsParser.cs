using Models.ConverterModels.Abstraction;
using System;
using System.Linq;
using System.Reflection;
using Common;
using System.ComponentModel;
using System.IO;
using System.Collections.Generic;

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
            var res = GetType(GetAssembly()
                            .GetTypes()
                            .ToList()
                            .FindAll(x => x.GetInterface("BaseUnitSystem") != type), text);

            resUnit = (BaseUnitSystem)Activator.CreateInstance(res);
            resUnit.Value = Decimal.Parse(textValue);
            return resUnit;
        }
        private static Assembly GetAssembly()
        {
            string path =  ResourceBll.ValuesConverterEntitiesPath;
            Assembly assembly = null;
            try
            {
                assembly = Assembly.LoadFrom(path);
            }
            catch 
            {
                throw new DirectoryNotFoundException($"Directory {path} was not found");
            }
            return assembly;
        }

        private static Type GetType(IEnumerable<Type> types, string text)
        {
            Type result = null;
            try
            {
                result = types
                    .ToList()
                    .Find(x => x.GetAttribute<DescriptionAttribute>().Description == text);
            }
            catch
            {

            }
            return result;
        }
    }
}
