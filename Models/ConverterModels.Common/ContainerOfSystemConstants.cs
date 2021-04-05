using Models.ConverterModels.Common.Interface;

using System;
using System.Collections.Generic;

namespace Models.ConverterModels.Common
{
    public class ContainerOfSystemConstants : IContainerOfSystemConstants
    {
        public Dictionary<string, decimal> Constants { get; set; }

        public ContainerOfSystemConstants(string text)
        {
            Constants = new Dictionary<string, decimal>();
            var lines = text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            foreach (var item in lines)
            {
                var strings = item.Split('-');
                Constants.Add(strings[0], Decimal.Parse(strings[1]));
            }
        }
    }
}
