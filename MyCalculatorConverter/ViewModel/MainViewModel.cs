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
using MyCalculatorConverter.View.ContentControls;

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

        private string _title;
        public string Title 
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private int _minHeightWindow = int.Parse(Resources.MinHeightSimpleCalc);
        public int MinHeightWindow
        {
            get { return _minHeightWindow; }
            set
            {
                _minHeightWindow = value;
                OnPropertyChanged();
            }
        }

        private int _minWidthtWindow = int.Parse(Resources.MinWidthSimpleCalc);
        public int MinWidthtWindow
        {
            get { return _minWidthtWindow; }
            set
            {
                _minWidthtWindow = value;
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
