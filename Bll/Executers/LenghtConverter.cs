using Bll.Executers.Abstractions;
using Bll.ValueConverters;
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
            SystemCalculus = new LengthCalculus();
        }

        public string Calculation(string text)
        {
           
        }
    }
}
