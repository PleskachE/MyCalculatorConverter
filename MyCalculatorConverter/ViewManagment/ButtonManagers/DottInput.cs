using MyCalculatorConverter.ViewManagment.ButtonManagers.Abstractions;

namespace MyCalculatorConverter.ViewManagment.ButtonManagers
{
    public class DottInput : ButtonManager
    {
        public DottInput()
        {
            IsDotInput = true;
            IsEqualsInput = false;
            IsWorkingSymbalInput = true;
        }
    }
}
