using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Abstraction.Common;
using System;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Megabyte")]
    public class Megabyte : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }
        public TypesMeasurementSystems Type { get; set; }
        public Megabyte()
        {
            Name = "Megabyte";
            Type = TypesMeasurementSystems.SystemMemory;
            isReferenceUnit = false;
        }

        public Megabyte(decimal value)
        {
            Name = "Megabyte";
            Type = TypesMeasurementSystems.SystemMemory;
            isReferenceUnit = false;
            Value = value;
        }

        public decimal RelationToReferenceUnit()
        {
            return Value * Decimal.Parse(Math.Pow(10, 6).ToString());
        }

        public decimal RelationToThisUnit(decimal unitValue)
        {
            return unitValue / Decimal.Parse(Math.Pow(10, 6).ToString());
        }
    }
}
