
namespace Common.ViewManagement.Interfaces
{
    public interface IButtonManager
    {
        bool IsWorkingSymbalInput { get; set; }
        bool IsDotInput { get; set; }
        bool IsEqualsInput { get; set; }
        void WorkingSymbalEntered();
        void DotEntered();
        void EqualsEntered();
    }
}
