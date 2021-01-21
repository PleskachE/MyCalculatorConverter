using MyCalculatorConverter.ViewManagment.ButtonManagers.Abstractions;

namespace MyCalculatorConverter.ViewManagment.ButtonManagers
{
    public class OperationSymbalInpyt : ButtonManager
    {
        public OperationSymbalInpyt()
        {
            IsWorkingSymbalInput = true;
            IsEqualsInput = false;
            IsDotInput = false;
        }
    }
}
