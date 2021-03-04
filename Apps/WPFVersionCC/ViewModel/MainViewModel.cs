using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Apps.WPFVersionCC.Infrastructure;
using Apps.WPFVersionCC.Infrastructure.Abstraction;
using Apps.WPFVersionCC.ViewModel.Abstraction;
using Apps.WPFVersionCC.ViewManagment;
using Apps.WPFVersionCC.ViewManagment.ButtonManagers.Abstractions;
using Apps.WPFVersionCC.ViewManagment.ButtonManagers;
using Apps.WPFVersionCC.Properties;
using Bll.Executers.Abstractions;
using Bll.Executers;
using System.Windows.Controls;
using Apps.WPFVersionCC.View.ContentControls;
using MyCalculatorConverter.Properties;

namespace Apps.WPFVersionCC.ViewModel
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
            Title = "Calculator";
            WorkingPlace = new CalculatorView();
        }

        public bool CanExecuteOpenCalculatorCommand(object parameter)
        {
            return true;
        }

        private void ExecuteOpenValueConverterCommand(object parameter)
        {
            Title = "ValueConverter";
            WorkingPlace = new ValueConverterView();
        }

        public bool CanExecuteOpenValueConverterCommand(object parameter)
        {
            return true;
        }

        private void ExecuteChacngingDesignThemeCommand(object parameter)
        {
            string _uri = Resources.StylePath + parameter as string + ".xaml";
            var newTheme = new ResourceDictionary();
            newTheme.Source = new Uri(_uri);
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(newTheme);
        }

        public bool CanExecuteChacngingDesignThemeCommand(object parameter)
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

        private string _title = "Calculator";
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
        public RelayCommand OpenValueConverterCommand { get; set; }
        public RelayCommand ChacngingDesignThemeCommand { get; set; }

        #endregion

        #region Methods

        private void GeneratingCommands()
        {
            OpenCalculatorCommand = new RelayCommand(ExecuteOpenCalculatorCommand, CanExecuteOpenCalculatorCommand);
            OpenValueConverterCommand = new RelayCommand(ExecuteOpenValueConverterCommand, CanExecuteOpenValueConverterCommand);
            ChacngingDesignThemeCommand = new RelayCommand(ExecuteChacngingDesignThemeCommand, CanExecuteChacngingDesignThemeCommand);
        }

        #endregion
    }
}
