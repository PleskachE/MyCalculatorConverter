using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MyCalculatorConverter.Algorithms;
using MyCalculatorConverter.Algorithms.Abstraction;
using MyCalculatorConverter.Converters;
using MyCalculatorConverter.Infrastructure;
using MyСalculatorConverter.Infrastructure;
using MyСalculatorConverter.Infrastructure.Abstraction;
using MyСalculatorConverter.Model;
using MyСalculatorConverter.ViewModel.Abstraction;
using MyСalculatorConverter.ViewManagement;
using MyСalculatorConverter.ViewManagement.Abstractions;
using MyCalculatorConverter.ViewManagment;

namespace MyСalculatorConverter.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields

        private IWindowFactory _windowFactory = new WindowFactory();

        private Number _result;
        private Number _leftNumber = new Number();
        private Number _rightNumber = new Number();

        private ICalculationAlgorithm _calculationAlgorithm;

        private bool _workingSymbalInput;
        private bool _dontInput = false;
        private bool _equalsInput = true;

        #endregion

        #region Ctors

        public MainViewModel()
        {
            GeneratingCommands();

            Display = new Display();
            Journal = new Journal();
            MainView = new MainSimpleCalculatorView();

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

        public RelayCommand PlusInputCommand { get; set; }
        public RelayCommand MinusInputCommand { get; set; }
        public RelayCommand MultiplyInputCommand { get; set; }
        public RelayCommand DivideInputCommand { get; set; }
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
            EqualsInput();
            var text = parameter as string;
            Display.NumbersInput(text);
        }
        public bool CanExecuteNumbersInputCommand(object parameter)
        {
            return Display.InputText.Length < SystemConstants.MaxCountInputSymabl;
        }

        #endregion

        #region SimpleCalculatorCommands

        private void ExecutePlusInputCommand(object parameter)
        {
            CheckingInput(_leftNumber);
            _calculationAlgorithm = new Summation();
            WorkingSymbalInput(" + ");
        }
        public bool CanExecutePlusInputCommand(object parameter)
        {
            return _workingSymbalInput != true; ;
        }

        private void ExecuteMinusInputCommand(object parameter)
        {
            CheckingInput(_leftNumber);
            _calculationAlgorithm = new Subtraction();
            WorkingSymbalInput(" - ");
        }
        public bool CanExecuteMinusInputCommand(object parameter)
        {
            return _workingSymbalInput != true; ;
        }

        private void ExecuteMultiplyInputCommand(object parameter)
        {
            CheckingInput(_leftNumber);
            _calculationAlgorithm = new Multiply();
            WorkingSymbalInput(" * ");
        }
        public bool CanExecuteMultiplyInputCommand(object parameter)
        {
            return _workingSymbalInput != true; ;
        }

        private void ExecuteDivideInputCommand(object parameter)
        {
            CheckingInput(_leftNumber);
            _calculationAlgorithm = new Division();
            WorkingSymbalInput(" / ");
        }
        public bool CanExecuteDivideInputCommand(object parameter)
        {
            return _workingSymbalInput != true;
        }

        private void ExecuteEqualsInputCommand(object parameter)
        {
            if (Display.InputText.Length != 0)
            {
                _rightNumber = new Number(NumbersConverter.StringToDoubleConvert(Display.InputText));
            }
            else { _rightNumber.Value = 0; }

            Journal.InputLeftPart(Display.OutputText);

            _result = _calculationAlgorithm.Result(_leftNumber, _rightNumber);
            _leftNumber = _result;
            var text = NumbersConverter.DoubleToStringConvert(_result.Value);
            Display.InputText = "";
            Display.OutputText = text;
            Journal.InputRightPart(Display.OutputText);

            _workingSymbalInput = false;
            _equalsInput = true;
            _dontInput = false;
        }
        public bool CanExecuteEqualsInputCommand(object parameter)
        {
            return (_equalsInput != true || Display.InputText.Length != 0);
        }

        #endregion

        #region ManagementCommands

        private void ExecuteDeleteAllCommand(object parameter)
        {
            _leftNumber.Value = 0;
            _rightNumber.Value = 0;
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

            PlusInputCommand = new RelayCommand(ExecutePlusInputCommand, CanExecutePlusInputCommand);
            MinusInputCommand = new RelayCommand(ExecuteMinusInputCommand, CanExecuteMinusInputCommand);
            MultiplyInputCommand = new RelayCommand(ExecuteMultiplyInputCommand, CanExecuteMultiplyInputCommand);
            DivideInputCommand = new RelayCommand(ExecuteDivideInputCommand, CanExecuteDivideInputCommand);
            EqualsInputCommand = new RelayCommand(ExecuteEqualsInputCommand, CanExecuteEqualsInputCommand);

            DeleteAllCommand = new RelayCommand(ExecuteDeleteAllCommand, CanExecuteDeleteAllCommand);
            DeleteOneNumberCommand = new RelayCommand(ExecuteDeleteOneNumberCommand, CanExecuteDeleteOneNumberCommand);
        }

        private void EqualsInput()
        {
            if (_equalsInput == true)
            {
                _equalsInput = false;
                Display.OutputText = "";
                _leftNumber.Value = 0;
            }
        }

        private void WorkingSymbalInput(string text)
        {
            _workingSymbalInput = true;
            _equalsInput = false;
            _dontInput = false;

            Display.WorkingSymbalInput(text);
        }

        private void CheckingInput(Number number)
        {
            if (Display.InputText.Length > 0)
            {
                _leftNumber = new Number(NumbersConverter.StringToDoubleConvert(Display.InputText));
            }
        }

        #endregion
    }
}
