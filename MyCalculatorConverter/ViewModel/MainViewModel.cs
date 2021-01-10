using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MyCalculatorConverter.Algorithms;
using MyCalculatorConverter.Algorithms.Abstraction;
using MyCalculatorConverter.Constants;
using MyCalculatorConverter.Converters;
using MyСalculatorConverter.Infrastructure;
using MyСalculatorConverter.Infrastructure.Abstraction;
using MyСalculatorConverter.Model;
using MyСalculatorConverter.ViewModel.Abstraction;

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

            DeleteOutput();

            VisSimpleCalc = Visibility.Visible;
            VisEngineeringCalc = Visibility.Hidden;
        }

        #endregion

        #region MenuCommand

        private void ExecuteOpenSimpleCalculatorCommand(object parameter)
        {
            VisSimpleCalc = Visibility.Visible;
            VisEngineeringCalc = Visibility.Hidden;
        }

        public bool CanExecuteOpenSimpleCalculatorCommand(object parameter)
        {
            return true;
        }

        private void ExecuteOpenEngineeringCalculatorCommand(object parameter)
        {
            VisSimpleCalc = Visibility.Hidden;
            VisEngineeringCalc = Visibility.Visible;
        }

        public bool CanExecuteOpenEngineeringCalculatorCommand(object parameter)
        {
            return true;
        }

        #endregion

        #region Properties

        public RelayCommand OpenSimpleCalculatorCommand { get; set; }
        public RelayCommand OpenEngineeringCalculatorCommand { get; set; }
        public RelayCommand ZeroInputCommand { get; set; }
        public RelayCommand OneInputCommand { get; set; }
        public RelayCommand TwoInputCommand { get; set; }
        public RelayCommand ThreeInputCommand { get; set; }
        public RelayCommand FourInputCommand { get; set; }
        public RelayCommand FiveInputCommand { get; set; }
        public RelayCommand SixInputCommand { get; set; }
        public RelayCommand SevenInputCommand { get; set; }
        public RelayCommand EightInputCommand { get; set; }
        public RelayCommand NineInputCommand { get; set; }

        public RelayCommand PlusInputCommand { get; set; }
        public RelayCommand MinusInputCommand { get; set; }
        public RelayCommand MultiplyInputCommand { get; set; }
        public RelayCommand DivideInputCommand { get; set; }
        public RelayCommand EqualsInputCommand { get; set; }
        public RelayCommand DotInputCommand { get; set; }

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

        private string _outputText;
        public string OutputText
        {
            get
            {
                return _outputText;
            }
            set
            {
                _outputText = value;
                OnPropertyChanged();
            }
        }

        private string _inputText;
        public string InputText
        {
            get
            {
                return _inputText;
            }
            set
            {
                _inputText = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region InputNumbersCommands

        private void ExecuteZeroInputCommand(object parameter)
        {
            EqualsInput();
            NumbersInput("0");
        }
        public bool CanExecuteZeroInputCommand(object parameter)
        {
            return _inputText.Length < SystemConstants.MaxCountInputSymabl;
        }

        private void ExecuteOneInputCommand(object parameter)
        {
            EqualsInput();
            NumbersInput("1");
        }
        public bool CanExecuteOneInputCommand(object parameter)
        {
            return _inputText.Length < SystemConstants.MaxCountInputSymabl; ;
        }

        private void ExecuteTwoInputCommand(object parameter)
        {
            EqualsInput();
            NumbersInput("2");
        }
        public bool CanExecuteTwoInputCommand(object parameter)
        {
            return _inputText.Length < SystemConstants.MaxCountInputSymabl; ;
        }

        private void ExecuteThreeInputCommand(object parameter)
        {
            EqualsInput();
            NumbersInput("3");
        }
        public bool CanExecuteThreeInputCommand(object parameter)
        {
            return _inputText.Length < SystemConstants.MaxCountInputSymabl; ;
        }

        private void ExecuteFourInputCommand(object parameter)
        {
            EqualsInput();
            NumbersInput("4");
        }
        public bool CanExecuteFourInputCommand(object parameter)
        {
            return _inputText.Length < SystemConstants.MaxCountInputSymabl; ;
        }

        private void ExecuteFiveInputCommand(object parameter)
        {
            EqualsInput();
            NumbersInput("5");
        }
        public bool CanExecuteFiveInputCommand(object parameter)
        {
            return _inputText.Length < SystemConstants.MaxCountInputSymabl; ;
        }

        private void ExecuteSixInputCommand(object parameter)
        {
            EqualsInput();
            NumbersInput("6");
        }
        public bool CanExecuteSixInputCommand(object parameter)
        {
            return _inputText.Length < SystemConstants.MaxCountInputSymabl; ;
        }

        private void ExecuteSevenInputCommand(object parameter)
        {
            EqualsInput();
            NumbersInput("7");
        }
        public bool CanExecuteSevenInputCommand(object parameter)
        {
            return _inputText.Length < SystemConstants.MaxCountInputSymabl; ;
        }

        private void ExecuteEightInputCommand(object parameter)
        {
            EqualsInput();
            NumbersInput("8");
        }
        public bool CanExecuteEightInputCommand(object parameter)
        {
            return _inputText.Length < SystemConstants.MaxCountInputSymabl; ;
        }

        private void ExecuteNineInputCommand(object parameter)
        {
            EqualsInput();
            NumbersInput("9");
        }
        public bool CanExecuteNineInputCommand(object parameter)
        {
            return _inputText.Length < SystemConstants.MaxCountInputSymabl; ;
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
            if (InputText.Length != 0)
            {
                _rightNumber = new Number(NumbersConverter.StringToDoubleConvert(InputText));
            }
            else { _rightNumber.Value = 0; }

            _result = _calculationAlgorithm.Result(_leftNumber, _rightNumber);
            _leftNumber = _result;
            var text = NumbersConverter.DoubleToStringConvert(_result.Value);
            InputText = "";
            OutputText = text;
            _workingSymbalInput = false;
            _equalsInput = true;
            _dontInput = false;
        }
        public bool CanExecuteEqualsInputCommand(object parameter)
        {
            return (_equalsInput != true || InputText.Length != 0);
        }

        private void ExecuteDotInputCommand(object parameter)
        {
            _dontInput = true;
            NumbersInput(",");
        }
        public bool CanExecuteDotInputCommand(object parameter)
        {
            return (_dontInput != true & InputText.Length != 0);
        }

        #endregion

        #region ManagementCommands

        private void ExecuteDeleteAllCommand(object parameter)
        {
            _leftNumber.Value = 0;
            _rightNumber.Value = 0;
            DeleteOutput();
        }
        public bool CanExecuteDeleteAllCommand(object parameter)
        {
            return OutputText.Length != 0;
        }

        private void ExecuteDeleteOneNumberCommand(object parameter)
        {
            InputText = InputText.Remove(InputText.Length - 1, 1);
            OutputText = OutputText.Remove(OutputText.Length - 1, 1);
        }
        public bool CanExecuteDeleteOneNumberCommand(object parameter)
        {
            return InputText.Length != 0;
        }

        #endregion

        #region Methods

        private void GeneratingCommands()
        {
            OpenSimpleCalculatorCommand = new RelayCommand(ExecuteOpenSimpleCalculatorCommand,
                CanExecuteOpenSimpleCalculatorCommand);
            OpenEngineeringCalculatorCommand = new RelayCommand(ExecuteOpenEngineeringCalculatorCommand,
                CanExecuteOpenEngineeringCalculatorCommand);

            ZeroInputCommand = new RelayCommand(ExecuteZeroInputCommand, CanExecuteZeroInputCommand);
            OneInputCommand = new RelayCommand(ExecuteOneInputCommand, CanExecuteOneInputCommand);
            TwoInputCommand = new RelayCommand(ExecuteTwoInputCommand, CanExecuteTwoInputCommand);
            ThreeInputCommand = new RelayCommand(ExecuteThreeInputCommand, CanExecuteThreeInputCommand);
            FourInputCommand = new RelayCommand(ExecuteFourInputCommand, CanExecuteFourInputCommand);
            FiveInputCommand = new RelayCommand(ExecuteFiveInputCommand, CanExecuteFiveInputCommand);
            SixInputCommand = new RelayCommand(ExecuteSixInputCommand, CanExecuteSixInputCommand);
            SevenInputCommand = new RelayCommand(ExecuteSevenInputCommand, CanExecuteSevenInputCommand);
            EightInputCommand = new RelayCommand(ExecuteEightInputCommand, CanExecuteEightInputCommand);
            NineInputCommand = new RelayCommand(ExecuteNineInputCommand, CanExecuteNineInputCommand);

            PlusInputCommand = new RelayCommand(ExecutePlusInputCommand, CanExecutePlusInputCommand);
            MinusInputCommand = new RelayCommand(ExecuteMinusInputCommand, CanExecuteMinusInputCommand);
            MultiplyInputCommand = new RelayCommand(ExecuteMultiplyInputCommand, CanExecuteMultiplyInputCommand);
            DivideInputCommand = new RelayCommand(ExecuteDivideInputCommand, CanExecuteDivideInputCommand);
            EqualsInputCommand = new RelayCommand(ExecuteEqualsInputCommand, CanExecuteEqualsInputCommand);
            DotInputCommand = new RelayCommand(ExecuteDotInputCommand, CanExecuteDotInputCommand);

            DeleteAllCommand = new RelayCommand(ExecuteDeleteAllCommand, CanExecuteDeleteAllCommand);
            DeleteOneNumberCommand = new RelayCommand(ExecuteDeleteOneNumberCommand, CanExecuteDeleteOneNumberCommand);
        }

        private void EqualsInput()
        {
            if (_equalsInput == true)
            {
                _equalsInput = false;
                OutputText = "";
                _leftNumber.Value = 0;
            }
        }

        private void NumbersInput(string text)
        {
            InputText += text;
            OutputText += text;
        }

        private void WorkingSymbalInput(string text)
        {
            _workingSymbalInput = true;
            _equalsInput = false;
            _dontInput = false;

            InputText = "";
            OutputText += text;
        }

        private void CheckingInput(Number number)
        {
            if (InputText.Length > 0)
            {
                _leftNumber = new Number(NumbersConverter.StringToDoubleConvert(InputText));
            }
        }

        private void DeleteOutput()
        {
            InputText = "";
            OutputText = "";
        }

        #endregion
    }
}
