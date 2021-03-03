﻿using Models.ConverterModels.Abstraction;

using System;
using System.ComponentModel;

namespace Models.ConverterModels.Entities.Units
{
    [Description("Yard")]
    public class Yard : IUnitSystem
    {
        public string Name { get; set; }
        public bool isReferenceUnit { get; set; }
        public decimal Value { get; set; }

        public Yard()
        {
            Name = "Yard";
        }

        public Yard(decimal value)
        {
            Name = "Yard";
            Value = value;
        }

        public decimal RelationToReferenceUnit()
        {
            return (Decimal.Parse("91.44") * Value);
        }

        public decimal RelationToThisUnit(decimal unitValue)
        {
            return (unitValue / Decimal.Parse("91.44"));
        }
    }
}