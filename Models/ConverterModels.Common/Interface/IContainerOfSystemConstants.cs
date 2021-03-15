using System.Collections.Generic;

namespace Models.ConverterModels.Common.Interface
{
    public interface IContainerOfSystemConstants
    {
        Dictionary<string, decimal> Constants { get; set; }
    }
}
