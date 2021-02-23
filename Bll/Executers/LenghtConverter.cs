using Bll.Executers.Abstractions;
using ConverterModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Executers
{
    public class LenghtConverter : ValueConverter, IExecuter
    {
        public LenghtConverter()
        {
            System = new LengthCalculus()
        }
    }
}
