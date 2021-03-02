using Models.ConverterModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ConverterModels.Entities
{
    public class MemorySystem : BaseSystem
    {
        public override BaseUnitSystem GetReferenceUnit()
        {
            throw new NotImplementedException();
        }
    }
}
