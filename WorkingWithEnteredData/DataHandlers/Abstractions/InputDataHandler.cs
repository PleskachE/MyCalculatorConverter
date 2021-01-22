
namespace WorkingWithEnteredData.DataHandlers.Abstractions
{
    public abstract class InputDataHandler
    {
        public virtual string Calculation(string operation) { return Result; }
        public string LeftNumber { get; set; }
        public string RightNumber { get; set; }
        public string Result { get; set; }
    }
}
