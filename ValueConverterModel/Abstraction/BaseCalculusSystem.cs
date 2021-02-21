﻿using System.Collections.Generic;
using ValueConverterModel.Common;

namespace ValueConverterModel.Abstraction
{
    public abstract class BaseCalculusSystem
    {
        public string Name { get; set; }
        public ICollection<ISystem> SystemsOfMeasurement { get; set; }
        public TypesCalculusSystems TypesSystems { get; set; }
    }
}
