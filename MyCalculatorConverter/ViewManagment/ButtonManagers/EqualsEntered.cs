using MyCalculatorConverter.ViewManagment.ButtonManagers.Abstractions;

namespace MyCalculatorConverter.ViewManagment.ButtonManagers
{
    public class EqualsEntered : ButtonManager
    {
        public EqualsEntered()
        {
            IsWorkingSymbalInput = false;
            IsEqualsInput = true;
            IsDotInput = false;
        }
    }
}
