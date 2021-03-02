using Models.ConverterModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ConverterModels.Entities
{
    public class WeightsSystem : BaseSystem
    {

        public WeightsSystem()
        {
            Name = "Система мер массы";
        }

        public override BaseUnitSystem GetReferenceUnit()
        {
            throw new NotImplementedException();
        }
    }
}
