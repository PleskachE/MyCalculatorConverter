using Apps.WPFVersionCC.ViewModel;

using Factories;

using System.Windows.Controls;

namespace Apps.WPFVersionCC.View.ContentControls
{
    /// <summary>
    /// Логика взаимодействия для CalculatorView.xaml
    /// </summary>
    public partial class CalculatorView : ContentControl
    {
        public CalculatorView()
        {
            AlgorithmsFactory factory = new AlgorithmsFactory();
            DataContext = new CalculatorViewModel(factory.GetContainerForAlgorithms());
            InitializeComponent();
        }
    }
}
