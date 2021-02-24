﻿using ConverterModels.Abstraction;

namespace ConverterModels.Entities.Units
{
    public class Kilometer : BaseUnitSystem
    {
        public Kilometer()
        {
            Name = "Kilometer";
        }

        public Kilometer(decimal value)
        {
            Name = "Kilometer";
            Value = value;
        }

        public override decimal RelationToReferenceUnit()
        {
            return (100000 * Value);
        }

        public override decimal RelationToThisUnit(decimal unitValue)
        {
            return (unitValue / 100000);
        }
    }
}
