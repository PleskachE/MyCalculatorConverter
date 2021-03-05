using System.IO;
using System.Reflection;

namespace Common
{
    public static class AssemblyLoader
    {
        public static Assembly LoadsAssemblyOnPath(string path)
        {
            Assembly assembly = null;
            try
            {
                assembly = Assembly.LoadFrom(path);
            }
            catch
            {
                throw new DirectoryNotFoundException($"Directory {path} was not found");
            }
            return assembly;
        }
    }
}
