using Common.extensions;
using Models.ConverterModels.Common;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Common.Loaders
{
    public static class TypeLoader
    {
        public static Type GetType(IEnumerable<Type> types, string text)
        {
            Type result = null;
            try
            {
                result = types
                    .ToList()
                    .Find(x => x.GetAttribute<DescriptionAttribute>().Description == text);
            }
            catch
            {
                var newItem = new DefaultUnit();
                result = newItem.GetType();
                
            }
            return result;
        }
    }
}
