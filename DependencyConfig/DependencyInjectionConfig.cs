using Algorithms;
using Algorithms.Interface;

using Ninject;
using Ninject.Modules;

using System.Collections.Generic;

namespace Apps.WPFVersionCC.Configure
{
    public class DependencyInjectionConfig
    {
        public DependencyInjectionConfig()
        {
            RegisterDependencies();
        }
        public StandardKernel Kernel { get; set; }
        public void RegisterDependencies()
        {
            var module = new Module();
            Kernel = new StandardKernel(module);
        }

        public IEnumerable<IAlgorithm> GetAlgorithms()
        {
            return Kernel.GetAll<IAlgorithm>();
        }

        private class Module : NinjectModule
        {
            public override void Load()
            {
                Bind<IAlgorithm>().To<ReversePolishNotation>();
                Bind<IAlgorithm>().To<PolishNotation>();
            }
        }
    }
}
