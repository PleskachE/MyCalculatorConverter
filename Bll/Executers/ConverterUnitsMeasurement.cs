using Bll.Executers.Abstractions;
using Bll.ValueConverterSupportTools;
using Common;
using Models.ConverterModels.Abstraction;

using System;

namespace Bll.Executers
{
    public class ConverterUnitsMeasurement : IExecuter
    {
        public BaseSystem SystemMeasuring { get; set; }

        public ConverterUnitsMeasurement(BaseSystem system)
        {
            SystemMeasuring = system;
        }

        public string Calculation(string text)
        {
            UnitsParser.Parse(text);
            var firstUnit = UnitsParser.GetFirstUnit();
            var resUnit = UnitsParser.GetLastUnit();
            var tempValue = firstUnit.RelationToReferenceUnit();
            var resValue = resUnit.RelationToThisUnit(tempValue);
            resValue = Math.Round(resValue, Constants.CountOfDecimalPlaces);
            return resValue.ToString();
        }
    }
}
