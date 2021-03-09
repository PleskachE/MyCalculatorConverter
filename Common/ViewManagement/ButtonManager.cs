using Common.ViewManagement.Interfaces;

namespace Common.ViewManagement
{
    public class ButtonManager : IButtonManager
    {
        public bool IsWorkingSymbalInput { get; set; }
        public bool IsDotInput { get; set; }
        public bool IsEqualsInput { get; set; }

        public ButtonManager()
        {
            IsDotInput = true;
            IsEqualsInput = true;
            IsWorkingSymbalInput = true;
        }

        public void DotEntered()
        {
            IsDotInput = true;
            IsEqualsInput = false;
            IsWorkingSymbalInput = true;
        }

        public void EqualsEntered()
        {
            IsWorkingSymbalInput = false;
            IsEqualsInput = true;
            IsDotInput = false;
        }

        public void WorkingSymbalEntered()
        {
            IsWorkingSymbalInput = true;
            IsEqualsInput = false;
            IsDotInput = false;
        }
    }
}
