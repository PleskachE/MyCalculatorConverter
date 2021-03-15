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
        IContainerOfSystemConstants _constants;
        public BaseSystem SystemMeasuring { get; set; }

        public ValueConverter(BaseSystem system)
        {
            SystemMeasuring = system;
            GeneratingHandlers();
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

        private void GeneratingHandlers()
        {
            switch (SystemMeasuring.Name)
            {
                case "Length Elements":
                    _constants = new LengthConstantsWithReferenceCentimeter();
                    break;
                case "Memory Elements":
                    _constants = new MemoryConstantsWithReferenceByte();
                    break;
                case "Mass Elements":
                    _constants = new WeightsConstantsWithReferenceKilogram();
                    break;
            }
        }
    }
}
