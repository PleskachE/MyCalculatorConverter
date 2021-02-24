﻿using ConverterModels.Abstraction;
using System;

namespace ConverterModels.Entities.Units
{
    public class Yard : BaseUnitSystem
    {
        public Yard()
        {
            Name = "Yard";
        }

        public Yard(decimal value)
        {
            Name = "Yard";
            Value = value;
        }

        public override decimal RelationToReferenceUnit()
        {
            return (Decimal.Parse("91.44") * Value);
        }

        public override decimal RelationToThisUnit(decimal unitValue)
        {
            return (unitValue / Decimal.Parse("91.44"));
        }
    }
}
