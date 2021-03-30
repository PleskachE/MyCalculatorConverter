using Apps.WPFVersionCC.ViewModel;

using System;
using System.Windows;
using System.Windows.Forms;

namespace Apps.WPFVersionCC.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
            NotifyIcon _ni = new NotifyIcon();
            _ni.Icon = MyCalculatorConverter.Properties.Resources.Logo;
            _ni.Visible = true;
            _ni.DoubleClick +=
                delegate (object sender, EventArgs args)
                {
                    this.Show();
                    this.WindowState = WindowState.Normal;
                };
        }
        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
                this.Hide();

            base.OnStateChanged(e);
        }
    }
}
