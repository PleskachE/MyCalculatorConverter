using Apps.WPFVersionCC.View;
using DependencyConfig;
using Ninject;
using System.Windows;

namespace Apps.WPFVersionCC
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        private IKernel _iocKernel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _iocKernel = new StandardKernel();
            _iocKernel.Load(new Module());
            Current.MainWindow = _iocKernel.Get<MainWindow>();
            Current.MainWindow.Show();
        }
    }
}
