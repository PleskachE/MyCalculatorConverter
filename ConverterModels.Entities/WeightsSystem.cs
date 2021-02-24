using ConverterModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterModels.Entities
{
    public class WeightsSystem : BaseSystem, ISystem
    {
        public BaseUnitSystem GetReferenceUnit()
        {
            throw new NotImplementedException();
        }
    }
}
