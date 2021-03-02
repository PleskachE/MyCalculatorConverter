using Bll.Executers.Abstractions;
using Bll.ValueConverters;
using Models.ConverterModels.Abstraction;

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
            return firstUnit.Value.ToString() + firstUnit.Name + "=" + resValue.ToString() + resUnit.Name;
        }
    }
}
