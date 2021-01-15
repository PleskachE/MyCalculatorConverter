using System.Windows;
using ViewManagementLibrary.Abstractions;

namespace ViewManagementLibrary
{
    public class MainSimpleCalculatorView : MainView
    {

        public MainSimpleCalculatorView()
        {
            SizeToContent = SizeToContent.WidthAndHeight;
            MinWidthWindow = 450;
            MinHeightWindow = 380;
            Title = "SimpleCalculator";
        }

        public override Window ChangeWindow(Window window)
        {
            window.SizeToContent = SizeToContent;
            window.Title = Title;
            window.MinHeight = MinHeightWindow;
            window.MinWidth = MinWidthWindow;
            return window;
        }
    }
}
