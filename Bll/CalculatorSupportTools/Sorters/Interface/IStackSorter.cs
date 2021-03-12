using Models.Calculator.Abstraction;

namespace Bll.CalculatorSupportTools.Sorters.Interface
{
    public interface IStackSorter
    {
        ICollectionChar Sort(ICollectionChar stack);
    }
}
