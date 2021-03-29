using Bll.Executers.Abstractions;
using Bll.ValueConverterSupportTools;

using Common;

using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Common;
using Models.ConverterModels.Common.Interface;

using System;

namespace Bll.Executers
{
    public class ValueConverter : IExecuter
    {
        private IValueHandler _valueHandler;
        private IContainerOfSystemConstants _constants;

        public BaseSystem SystemMeasuring { get; set; }

        public ValueConverter(BaseSystem system)
        {
            SystemMeasuring = system;
            _constants = new ContainerOfSystemConstants(GeneratingPath());
            _valueHandler = new ValueHandler();
        }

        public string Calculation(string text)
        {
            UnitsParser.Parse(text);
            var firstUnit = UnitsParser.GetFirstUnit();
            var resUnit = UnitsParser.GetLastUnit();
            var tempValue = _valueHandler.RelationToReferenceUnit(firstUnit.Value, _constants.Constants[firstUnit.Name]); 
            var resValue = _valueHandler.RelationToThisUnit(tempValue, _constants.Constants[resUnit.Name]);
            resValue = Math.Round(resValue, Constants.CountOfDecimalPlaces);
            return resValue.ToString();
        }

        private string GeneratingPath()
        {
            string path = null;
            switch (SystemMeasuring.Name)
            {
                case "Length Elements":
                    path = Bll_Resource.LenghtConstantsPath;
                    break;
                case "Memory Elements":
                    path = Bll_Resource.MemoryConstantsPath;
                    break;
                case "Mass Elements":
                    path = Bll_Resource.WeightsConstantsPath;
                    break;
            }
            return path;
        }
    }
}
