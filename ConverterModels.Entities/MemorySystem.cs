﻿using ConverterModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterModels.Entities
{
    public class MemorySystem : BaseSystem
    {
        public override BaseUnitSystem GetReferenceUnit()
        {
            throw new NotImplementedException();
        }
    }
}