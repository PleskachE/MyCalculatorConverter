﻿using Models.ConverterModels.Abstraction;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Decimeter")]
    public class Decimeter : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }

        public Decimeter()
        {
            Name = "Decimeter";
        }

        public Decimeter(decimal value)
        {
            Name = "Decimeter";
            Value = value;
        }

        public decimal RelationToReferenceUnit()
        {
            return (Value * 10);
        }

        public decimal RelationToThisUnit(decimal unitValue)
        {
            return (unitValue / 10);
        }
    }
}