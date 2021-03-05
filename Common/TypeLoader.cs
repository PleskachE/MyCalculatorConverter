using Common.extensions;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Common
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
                result = types
                   .ToList()
                   .Find(x => x.GetAttribute<DescriptionAttribute>().Description == "Default");
            }
            return result;
        }
    }
}
