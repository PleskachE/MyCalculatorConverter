
namespace MyCalculatorConverter.ViewManagment.ButtonManagers.Abstractions
{
    public abstract class ButtonManager
    {
        public bool IsWorkingSymbalInput { get; set; }
        public bool IsDotInput { get; set; }
        public bool IsEqualsInput { get; set; }
    }
}
