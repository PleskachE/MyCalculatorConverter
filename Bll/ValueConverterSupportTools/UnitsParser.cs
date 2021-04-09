using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;

using System;
using System.Linq;

using Common;
using Common.extensions;
using Common.Loaders;

using NLog;

namespace Bll.ValueConverterSupportTools
{
    public static class UnitsParser
    {
        private static IUnitSystem[] _units = new IUnitSystem[2];
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static void Parse(string text)
        {
            string firstElem;
            string lastElem;
            try
            {
                firstElem = text.Substring(0, text.LastIndexOf("="));
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                firstElem = "0";
            }
            try
            {
                lastElem = text.Substring(text.LastIndexOf("="), text.Count() - firstElem.Count());
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                lastElem = "0";
            }
            _units[0] = CreatingNewUnit(firstElem);
            _units[1] = CreatingNewUnit(lastElem);
        }

        public static IUnitSystem GetFirstUnit() 
        {
            if(_units[0] == null )
            {
                _units[0] = new DefaultUnit();
            }
            return _units[0]; 
        }
        public static IUnitSystem GetLastUnit() 
        {
            if (_units[1] == null)
            {
                _units[1] = new DefaultUnit();
            }
            return _units[1];
        }

        private static IUnitSystem CreatingNewUnit(string text)
        {
            var textValue = text.GetNumbersFromString();
            text = text.Remove(0, textValue.Length);
            var res = TypeLoader.GetType
                (ClassCollectionLoader.loadsTypesImplementInterface
                (AssemblyLoader.LoadsAssemblyOnPath(Constants.ValuesConverterEntitiesPath), "IUnitSystem"), text);
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
