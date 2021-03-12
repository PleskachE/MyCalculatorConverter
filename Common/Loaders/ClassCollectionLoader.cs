using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Common.Loaders
{
    public static class ClassCollectionLoader
    {
        public static ICollection<Type> LoadAllTypesFromAssembly(Assembly assembly)
        {
            return assembly.GetTypes();
        }

        public static ICollection<Type> loadsTypesImplementInterface(Assembly assembly, string interfaceName)
        {
            Type type = Type.GetType(interfaceName);
            return assembly.GetTypes().ToList().FindAll(x => x.GetInterface(interfaceName) != type);
        }
    }
}
