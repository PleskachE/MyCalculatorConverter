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
        private static IUnitSystem[] _units = new IUnitSystem[2];

        public static void Parse(string text)
        {
            var firstElem = text.Substring(0, text.LastIndexOf("="));
            var lastElem = text.Substring(text.LastIndexOf("=") + 1, text.Count() - firstElem.Count() - 1);
            _units[0] = CreatingNewUnit(firstElem);
            _units[1] = CreatingNewUnit(lastElem);
        }

        public static IUnitSystem GetFirstUnit() { return _units[0]; }
        public static IUnitSystem GetLastUnit() { return _units[1]; }

        private static IUnitSystem CreatingNewUnit(string text)
        {
            char[] numbers = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ',' };
            var chairs = text.Intersect(numbers);
            string textValue = "";
            foreach(var item in chairs)
            {
                textValue += item.ToString();
            }
            text = text.Remove(0, textValue.Length);
            IUnitSystem resUnit = null;

            Type type = Type.GetType("IUnitSystem");
            var res = GetType(GetAssembly()
                            .GetTypes()
                            .ToList()
                            .FindAll(x => x.GetInterface("IUnitSystem") != type), text);

            resUnit = (IUnitSystem)Activator.CreateInstance(res);
            if(textValue == "")
            {
                textValue = "0";
            }
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
                result = types
                   .ToList()
                   .Find(x => x.GetAttribute<DescriptionAttribute>().Description == "Default");
            }
            return result;
        }
    }
}
