using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using Apps.WPFVersionCC.Infrastructure;
using Apps.WPFVersionCC.ViewModel.Abstraction;
using Apps.WPFVersionCC.View.ContentControls;

using MyCalculatorConverter.Properties;

using Algorithms.Interface;

using Factories.Abstraction;

using Common.ViewManagement.Interfaces;

using Models.ConverterModels.Abstraction;

namespace Apps.WPFVersionCC.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields

        private IWindowFactory          _windowFactory;
        private IEnumerable<IAlgorithm> _alghoritms;
        private IDisplay                _display;
        private IJournal                _journal;
        private IButtonManager          _buttonManager;
        private IEnumerable<BaseSystem> _systems;

        #endregion

        #region Ctors

        public MainViewModel(IEnumerable<IAlgorithm> alghoritms, IEnumerable<BaseSystem> systems,
            IWindowFactory windowFactory, IDisplay display, IJournal journal, IButtonManager buttonManager)
        {
            _alghoritms    = alghoritms;
            _windowFactory = windowFactory;
            _display       = display;
            _journal       = journal;
            _buttonManager = buttonManager;
            _systems       = systems;

            GeneratingCommands();
        }

        #endregion

        #region MenuCommand

        private void ExecuteOpenCalculatorCommand(object parameter)
        {
            Title = "Calculator";
            _journal.TextList.Clear();
            WorkingPlace = new CalculatorView(new CalculatorViewModel(_alghoritms, _display, _journal, _buttonManager));
        }
        public bool CanExecuteOpenCalculatorCommand(object parameter)
        {
            return true;
        }

        private void ExecuteOpenValueConverterCommand(object parameter)
        {
            Title = "ValueConverter";
            _journal.TextList.Clear();
            WorkingPlace = new ValueConverterView(new ValueConverterViewModel(_display, _journal, _buttonManager, _systems));
        }
        public bool CanExecuteOpenValueConverterCommand(object parameter)
        {
            return true;
        }

        private void ExecuteChacngingDesignThemeCommand(object parameter)
        {
            var newTheme = new ResourceDictionary();
            newTheme.Source = new Uri(DefiningPathToResourceFile(parameter as string));
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(newTheme);
        }
        public bool CanExecuteChacngingDesignThemeCommand(object parameter)
        {
            return true;
        }

        private void ExecuteCloseAppCommand(object parameter)
        {
            Application.Current.MainWindow.Close();
        }
        public bool CanExecuteCloseAppCommand(object parameter)
        {
            return true;
        }

        #endregion

        #region Properties

        private ContentControl _workingPlace;
        public ContentControl WorkingPlace
        {
            get 
            {
                if(_workingPlace == null)
                {
                    _workingPlace = new CalculatorView(new CalculatorViewModel(_alghoritms, _display, _journal, _buttonManager));
                }
                return _workingPlace; 
            }
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

        public RelayCommand OpenCalculatorCommand       { get; set; }
        public RelayCommand OpenValueConverterCommand   { get; set; }
        public RelayCommand ChacngingDesignThemeCommand { get; set; }
        public RelayCommand CloseAppCommand             { get; set; }

        #endregion

        #region Methods

        private void GeneratingCommands()
        {
            OpenCalculatorCommand       = new RelayCommand(ExecuteOpenCalculatorCommand        , CanExecuteOpenCalculatorCommand);
            OpenValueConverterCommand   = new RelayCommand(ExecuteOpenValueConverterCommand    , CanExecuteOpenValueConverterCommand);
            ChacngingDesignThemeCommand = new RelayCommand(ExecuteChacngingDesignThemeCommand  , CanExecuteChacngingDesignThemeCommand);
            CloseAppCommand             = new RelayCommand(ExecuteCloseAppCommand              , CanExecuteCloseAppCommand);
        }

        public string DefiningPathToResourceFile(string text)
        {
            string _uri = Resources.StylePathStandartTheme; //default style//
            switch (text)
            {
                case ("GreenTheme"):
                    {
                        _uri = Resources.StylePathGreenTheme;
                        break;
                    }
                case ("StandartTheme"):
                    {
                        _uri = Resources.StylePathStandartTheme;
                        break;
                    }
            }
            return _uri;
        }

        #endregion
    }
}
