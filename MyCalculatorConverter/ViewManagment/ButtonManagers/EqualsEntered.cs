using Apps.WPFVersionCC.ViewManagment.ButtonManagers.Abstractions;

namespace Apps.WPFVersionCC.ViewManagment.ButtonManagers
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
