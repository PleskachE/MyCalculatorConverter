
using WorkingWithEnteredData.Common;

namespace WorkingWithEnteredData.DataHandlers.Abstractions
{
    public abstract class InputDataHandler
    {
        public virtual double Calculation(Operation operation) { return Result; }
        public double LeftNumber { get; set; }
        public double RightNumber { get; set; }
        public double Result { get; set; }
    }
}
