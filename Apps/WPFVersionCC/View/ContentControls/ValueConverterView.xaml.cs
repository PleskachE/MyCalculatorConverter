using Apps.WPFVersionCC.ViewModel;

using System.Windows.Controls;

namespace Apps.WPFVersionCC.View.ContentControls
{
    /// <summary>
    /// Логика взаимодействия для ValueConverterView.xaml
    /// </summary>
    public partial class ValueConverterView : ContentControl
    {
        public ValueConverterView(ValueConverterViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
