using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MyCalculatorConverter.Algorithms;
using MyCalculatorConverter.Algorithms.Abstraction;
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
        private bool _dontInput;
        private bool _equalsInput;

        #endregion

        #region Ctors

        public MainViewModel()
        {
            GeneratingCommands();

            InputText = "";
            OutputText = "";

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
            InputText += "0";
            OutputText += "0";
        }
        public bool CanExecuteZeroInputCommand(object parameter)
        {
            return _inputText.Length < 10;
        }

        private void ExecuteOneInputCommand(object parameter)
        {
            InputText += "1";
            OutputText += "1";
        }
        public bool CanExecuteOneInputCommand(object parameter)
        {
            return _inputText.Length < 10; ;
        }

        private void ExecuteTwoInputCommand(object parameter)
        {
            InputText += "2";
            OutputText += "2";
        }
        public bool CanExecuteTwoInputCommand(object parameter)
        {
            return _inputText.Length < 10; ;
        }

        private void ExecuteThreeInputCommand(object parameter)
        {
            InputText += "3";
            OutputText += "3";
        }
        public bool CanExecuteThreeInputCommand(object parameter)
        {
            return _inputText.Length < 10; ;
        }

        private void ExecuteFourInputCommand(object parameter)
        {
            InputText += "4";
            OutputText += "4";
        }
        public bool CanExecuteFourInputCommand(object parameter)
        {
            return _inputText.Length < 10; ;
        }

        private void ExecuteFiveInputCommand(object parameter)
        {
            InputText += "5";
            OutputText += "5";
        }
        public bool CanExecuteFiveInputCommand(object parameter)
        {
            return _inputText.Length < 10; ;
        }

        private void ExecuteSixInputCommand(object parameter)
        {
            InputText += "6";
            OutputText += "6";
        }
        public bool CanExecuteSixInputCommand(object parameter)
        {
            return _inputText.Length < 10; ;
        }

        private void ExecuteSevenInputCommand(object parameter)
        {
            InputText += "7";
            OutputText += "7";
        }
        public bool CanExecuteSevenInputCommand(object parameter)
        {
            return _inputText.Length < 10; ;
        }

        private void ExecuteEightInputCommand(object parameter)
        {
            InputText += "8";
            OutputText += "8";
        }
        public bool CanExecuteEightInputCommand(object parameter)
        {
            return _inputText.Length < 10; ;
        }

        private void ExecuteNineInputCommand(object parameter)
        {
            InputText += "9";
            OutputText += "9";
        }
        public bool CanExecuteNineInputCommand(object parameter)
        {
            return _inputText.Length < 10; ;
        }

        #endregion

        #region SimpleCalculatorCommands

        private void ExecutePlusInputCommand(object parameter)
        {
            _leftNumber = new Number(NumbersConverter.StringToDoubleConvert(InputText));
            _calculationAlgorithm = new Summation();
            InputText = "";
            OutputText += " + ";
        }
        public bool CanExecutePlusInputCommand(object parameter)
        {
            return true;
        }

        private void ExecuteMinusInputCommand(object parameter)
        {
            _leftNumber = new Number(NumbersConverter.StringToDoubleConvert(InputText));
            _calculationAlgorithm = new Subtraction();
            InputText = "";
            OutputText += " - ";
        }
        public bool CanExecuteMinusInputCommand(object parameter)
        {
            return true;
        }

        private void ExecuteMultiplyInputCommand(object parameter)
        {
            _leftNumber = new Number(NumbersConverter.StringToDoubleConvert(InputText));
            _calculationAlgorithm = new Multiply();
            InputText = "";
            OutputText += " * ";
        }
        public bool CanExecuteMultiplyInputCommand(object parameter)
        {
            return true;
        }

        private void ExecuteDivideInputCommand(object parameter)
        {
            _leftNumber = new Number(NumbersConverter.StringToDoubleConvert(InputText));
            _calculationAlgorithm = new Division();
            InputText = "";
            OutputText += " / ";
        }
        public bool CanExecuteDivideInputCommand(object parameter)
        {
            return true;
        }

        private void ExecuteEqualsInputCommand(object parameter)
        {
            _rightNumber = new Number(NumbersConverter.StringToDoubleConvert(InputText));
            _result = _calculationAlgorithm.Result(_leftNumber, _rightNumber);
            _leftNumber = _result;
            var text = NumbersConverter.DoubleToStringConvert(_result.Value);
            InputText = "";
            OutputText = text;
        }
        public bool CanExecuteEqualsInputCommand(object parameter)
        {
            return true;
        }

        private void ExecuteDotInputCommand(object parameter)
        {
            InputText += ",";
            OutputText += ",";
        }
        public bool CanExecuteDotInputCommand(object parameter)
        {
            return true;
        }

        #endregion

        #region ManagementCommands

        private void ExecuteDeleteAllCommand(object parameter)
        {
            _leftNumber.Value = 0;
            _rightNumber.Value = 0;
            InputText = "";
            OutputText = "";
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

        #endregion
    }
}
