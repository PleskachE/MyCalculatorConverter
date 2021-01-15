using System.Windows;

namespace ViewManagementLibrary.Abstractions
{
    public interface IMainView
    {
        Window ChangeWindow(Window window);
    }
}
