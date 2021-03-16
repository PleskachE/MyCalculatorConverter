using Models.ConverterModels.Common.Interface;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Models.ConverterModels.Common
{
    public class ContainerOfSystemConstants : IContainerOfSystemConstants
    {
        public Dictionary<string, decimal> Constants { get; set; }

        public ContainerOfSystemConstants(string path)
        {
            Constants = new Dictionary<string, decimal>();
            string line;
            using (var sr = new StreamReader(path, Encoding.Default))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    var strings = line.Split('-');
                    Constants.Add(strings[0], Decimal.Parse(strings[1]));
                }
            }
        }
    }
}
