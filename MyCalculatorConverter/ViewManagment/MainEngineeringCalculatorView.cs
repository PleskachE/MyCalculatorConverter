using System.Windows;
using MyСalculatorConverter.ViewManagement.Abstractions;

namespace MyСalculatorConverter.ViewManagement
{
    public class MainEngineeringCalculatorView : MainView
    {
        public MainEngineeringCalculatorView()
        {
            SizeToContent = SizeToContent.WidthAndHeight;
            MinWidthWindow = 900;
            MinHeightWindow = 380;
            Title = "EngineeringCalculator";
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
