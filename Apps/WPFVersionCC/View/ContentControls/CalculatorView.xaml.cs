using Apps.WPFVersionCC.Configure;
using Apps.WPFVersionCC.ViewModel;

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
            DependencyInjectionConfig conteiner = new DependencyInjectionConfig();
            DataContext = new CalculatorViewModel(conteiner.GetAlgorithms());
            InitializeComponent();
        }
    }
}
