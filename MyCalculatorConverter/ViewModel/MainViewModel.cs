using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MyСalculatorConverter.Infrastructure;
using MyСalculatorConverter.Infrastructure.Abstraction;
using MyСalculatorConverter.Model;
using MyСalculatorConverter.ViewModel.Abstraction;
using MyСalculatorConverter.ViewManagement;
using MyСalculatorConverter.ViewManagement.Abstractions;
using MyCalculatorConverter.ViewManagment;
using WorkingWithEnteredData.DataHandlers.Abstractions;
using WorkingWithEnteredData.DataHandlers;
using WorkingWithEnteredData.Converters;
using WorkingWithEnteredData.Common;

namespace MyСalculatorConverter.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields

        private IWindowFactory _windowFactory = new WindowFactory();

        private InputDataHandler _inputDataHandler;

        private NumbersConverter _numbersConverter = new NumbersConverter();
        private OperationConverter _operationConverter = new OperationConverter();

        private Operation _operation;

        private bool _isWorkingSymbalInput;
        private bool _isDontInput = false;
        private bool _isEqualsInput = true;

        #endregion

        #region Ctors

        public MainViewModel()
        {
            GeneratingCommands();

            Display = new Display();
            Journal = new Journal();
            MainView = new MainSimpleCalculatorView();

            _inputDataHandler = new Calculator();

            VisSimpleCalc = Visibility.Visible;
            VisEngineeringCalc = Visibility.Hidden;
        }

        #endregion

        #region MenuCommand

        private void ExecuteOpenSimpleCalculatorCommand(object parameter)
        {
            VisSimpleCalc = Visibility.Visible;
            VisEngineeringCalc = Visibility.Hidden;

            MainView = new MainSimpleCalculatorView();
            Application.Current.MainWindow = MainView.ChangeWindow(Application.Current.MainWindow);

            _inputDataHandler = new Calculator();
        }

        public bool CanExecuteOpenSimpleCalculatorCommand(object parameter)
        {
            return true;
        }

        private void ExecuteOpenEngineeringCalculatorCommand(object parameter)
        {
            VisSimpleCalc = Visibility.Hidden;
            VisEngineeringCalc = Visibility.Visible;

            MainView = new MainEngineeringCalculatorView();
            Application.Current.MainWindow = MainView.ChangeWindow(Application.Current.MainWindow);

            _inputDataHandler = new Calculator();
        }

        public bool CanExecuteOpenEngineeringCalculatorCommand(object parameter)
        {
            return true;
        }

        #endregion

        #region Properties

        public Display Display { get; set; }

        public Journal Journal { get; set; }

        public MainView MainView { get; set; }

        public RelayCommand OpenSimpleCalculatorCommand { get; set; }
        public RelayCommand OpenEngineeringCalculatorCommand { get; set; }

        public RelayCommand NumbersInputCommand { get; set; }

        public RelayCommand OperationInputCommand { get; set; }
        public RelayCommand DontInputCommand { get; set; }
        public RelayCommand EqualsInputCommand { get; set; }

        public RelayCommand DeleteAllCommand { get; set; }
        public RelayCommand DeleteOneNumberCommand { get; set; }

        private Visibility _visSimpleCalc;
        public Visibility VisSimpleCalc
        {
            get
            {
                return _visSimpleCalc;
            }
            set
            {
                _visSimpleCalc = value;
                OnPropertyChanged();
            }
        }

        private Visibility _visEngineeringCalc;
        public Visibility VisEngineeringCalc
        {
            get
            {
                return _visEngineeringCalc;
            }
            set
            {
                _visEngineeringCalc = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region InputNumbersCommands

        private void ExecuteNumbersInputCommand(object parameter)
        {
            var text = parameter as string;
            Display.NumbersInput(text);

            _isEqualsInput = false;
            _isWorkingSymbalInput = false;
        }
        public bool CanExecuteNumbersInputCommand(object parameter)
        {
            return Display.InputText.Length < 14; // временное решение, заменить на константу в файле ресурсов
        }

        private void ExecuteDontInputCommand(object parameter)
        {
            var text = parameter as string;
            Display.NumbersInput(text);

            _isDontInput = true;
            _isEqualsInput = true;
            _isWorkingSymbalInput = true;
        }
        public bool CanExecuteDontInputCommand(object parameter)
        {
            return _isDontInput != true;
        }

        #endregion

        #region SimpleCalculatorCommands
        //неправильно работает!
        private void ExecuteOperationInputCommand(object parameter)
        {
            _isWorkingSymbalInput = true;
            _isDontInput = false;
            _isEqualsInput = false;

            if (Display.InputText != "")
            {
                _inputDataHandler.LeftNumber = _numbersConverter.StringToDouble(Display.InputText);
            }
            _operation = _operationConverter.StringToOperation(parameter as string);

            Display.WorkingSymbalInput(parameter as string);
        }
        public bool CanExecuteOperationInputCommand(object parameter)
        {
            return _isWorkingSymbalInput != true; ;
        }
        //не правильно работает
        private void ExecuteEqualsInputCommand(object parameter)
        {
            Journal.InputLeftPart(Display.OutputText);
            _inputDataHandler.RightNumber = _numbersConverter.StringToDouble(Display.InputText);
            var text = _inputDataHandler.Calculation(_operation).ToString();
            Display.OutputText += (parameter as string) + text;
            Journal.InputRightPart(text);
            _inputDataHandler.LeftNumber = _inputDataHandler.Result;

            _isEqualsInput = true;
            _isDontInput = false;
            _isWorkingSymbalInput = false;
        }
        public bool CanExecuteEqualsInputCommand(object parameter)
        {
            return (_isEqualsInput != true || Display.InputText.Length != 0);
        }

        #endregion

        #region ManagementCommands

        private void ExecuteDeleteAllCommand(object parameter)
        {
            _inputDataHandler.LeftNumber = 0;
            _inputDataHandler.RightNumber = 0;
            Display.DeleteOutput();
        }
        public bool CanExecuteDeleteAllCommand(object parameter)
        {
            return Display.OutputText.Length != 0;
        }

        private void ExecuteDeleteOneNumberCommand(object parameter)
        {
            Display.InputText = Display.InputText.Remove(Display.InputText.Length - 1, 1);
            Display.OutputText = Display.OutputText.Remove(Display.OutputText.Length - 1, 1);
        }
        public bool CanExecuteDeleteOneNumberCommand(object parameter)
        {
            return Display.InputText.Length != 0;
        }

        #endregion

        #region Methods

        private void GeneratingCommands()
        {
            OpenSimpleCalculatorCommand = new RelayCommand(ExecuteOpenSimpleCalculatorCommand,
                CanExecuteOpenSimpleCalculatorCommand);
            OpenEngineeringCalculatorCommand = new RelayCommand(ExecuteOpenEngineeringCalculatorCommand,
                CanExecuteOpenEngineeringCalculatorCommand);

            NumbersInputCommand = new RelayCommand(ExecuteNumbersInputCommand, CanExecuteNumbersInputCommand);

            OperationInputCommand = new RelayCommand(ExecuteOperationInputCommand, CanExecuteOperationInputCommand);
            DontInputCommand = new RelayCommand(ExecuteDontInputCommand, CanExecuteDontInputCommand);
            EqualsInputCommand = new RelayCommand(ExecuteEqualsInputCommand, CanExecuteEqualsInputCommand);

            DeleteAllCommand = new RelayCommand(ExecuteDeleteAllCommand, CanExecuteDeleteAllCommand);
            DeleteOneNumberCommand = new RelayCommand(ExecuteDeleteOneNumberCommand, CanExecuteDeleteOneNumberCommand);
        }


        private void WorkingSymbalInput(string text)
        {
            _isWorkingSymbalInput = true;
            _isEqualsInput = false;
            _isDontInput = false;

            Display.WorkingSymbalInput(text);
        }

        #endregion
    }
}
