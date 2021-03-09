
namespace Common.ViewManagement.Interfaces
{
    public interface IDisplay
    {
        string OutputText { get; set; }
        string InputText { get; set; }
        void DeleteOutput();
        void NumbersInput(string text);
        void WorkingSymbalInput(string text);
        void EqualsInput(string text);
        void AddNumber(string text);
    }
}
