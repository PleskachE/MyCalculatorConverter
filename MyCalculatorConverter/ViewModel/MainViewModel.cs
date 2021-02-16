using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MyСalculatorConverter.Infrastructure;
using MyСalculatorConverter.Infrastructure.Abstraction;
using MyСalculatorConverter.ViewModel.Abstraction;
using MyСalculatorConverter.ViewManagement;
using MyСalculatorConverter.ViewManagement.Abstractions;
using MyCalculatorConverter.ViewManagment;
using MyCalculatorConverter.ViewManagment.ButtonManagers.Abstractions;
using MyCalculatorConverter.ViewManagment.ButtonManagers;
using MyCalculatorConverter.Properties;
using Bll.Executers.Abstractions;
using Bll.Executers;
using System.Windows.Controls;
using MyCalculatorConverter.View;

namespace MyСalculatorConverter.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields

        private IWindowFactory _windowFactory = new WindowFactory();

        #endregion

        #region Ctors

        public MainViewModel()
        {
            GeneratingCommands();
        }

        #endregion

        #region MenuCommand

        private void ExecuteOpenCalculatorCommand(object parameter)
        {
            WorkingPlace = new CalculatorView();
        }

        public bool CanExecuteOpenCalculatorCommand(object parameter)
        {
            return true;
        }

        #endregion

        #region Properties

        private ContentControl _workingPlace = new CalculatorView();
        public ContentControl WorkingPlace
        {
            get { return _workingPlace; }
            set
            {
                _workingPlace = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand OpenCalculatorCommand { get; set; }

        #endregion

        #region Methods

        private void GeneratingCommands()
        {
            OpenCalculatorCommand = new RelayCommand(ExecuteOpenCalculatorCommand, CanExecuteOpenCalculatorCommand);
        }

        #endregion
    }
}
