using Algorithms;
using Algorithms.Interface;

using Common.ViewManagement;
using Common.ViewManagement.Interfaces;

using Factories;
using Factories.Abstraction;

using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Entities;

using Ninject.Modules;

using NumberSystemConverter;
using NumberSystemConverter.abstraction;

namespace DependencyConfig
{
    public class Module : NinjectModule
    {
        public override void Load()
        {
            Bind<IAlgorithm>().      To<ReversePolishNotation>();
            Bind<IAlgorithm>().      To<PolishNotation>();
            Bind<IWindowFactory>().  To<WindowFactory>();
            Bind<IDisplay>().        To<Display>();
            Bind<IJournal>().        To<Journal>();
            Bind<IButtonManager>().  To<ButtonManager>();
            Bind<BaseSystem>().      To<LengthSystem>();
            Bind<BaseSystem>().      To<WeightsSystem>();
            Bind<BaseSystem>().      To<MemorySystem>();
            Bind<INumberConverter>().To<DecimalToBinaryConverter>();
            Bind<INumberConverter>().To<BinaryToDecimalConverter>();
        }
    }
}
