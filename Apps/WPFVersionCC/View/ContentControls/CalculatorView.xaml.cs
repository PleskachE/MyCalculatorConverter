using Apps.WPFVersionCC.ViewModel;

using System.Windows.Controls;

namespace Apps.WPFVersionCC.View.ContentControls
{
    /// <summary>
    /// Логика взаимодействия для CalculatorView.xaml
    /// </summary>
    public partial class CalculatorView : ContentControl
    {
        public CalculatorView(CalculatorViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
