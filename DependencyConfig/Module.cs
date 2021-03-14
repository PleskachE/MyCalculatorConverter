using Algorithms;
using Algorithms.Interface;

using Ninject.Modules;

namespace DependencyConfig
{
    public class Module : NinjectModule
    {
        public override void Load()
        {
            Bind<IAlgorithm>().To<ReversePolishNotation>();
            Bind<IAlgorithm>().To<PolishNotation>();
        }
    }
}
