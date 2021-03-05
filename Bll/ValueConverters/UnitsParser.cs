using Models.ConverterModels.Abstraction;

using System;
using System.Linq;
using System.Reflection;

using Common.extensions;

using System.ComponentModel;
using System.IO;
using System.Collections.Generic;
using Common;

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

            var res = TypeLoader.GetType
                (ClassCollectionLoader.loadsTypesImplementInterface
                (AssemblyLoader.LoadsAssemblyOnPath(ResourceBll.ValuesConverterEntitiesPath), "IUnitSystem"), text);

            var resUnit = (IUnitSystem)Activator.CreateInstance(res);
            if(textValue == "")
            {
                textValue = "0";
            }
            resUnit.Value = Decimal.Parse(textValue);
            return resUnit;
        }
    }
}
