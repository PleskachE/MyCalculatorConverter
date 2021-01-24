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
using WorkingWithEnteredData.DataHandlers.Abstractions;
using WorkingWithEnteredData.DataHandlers;
using MyCalculatorConverter.ViewManagment.ButtonManagers.Abstractions;
using MyCalculatorConverter.ViewManagment.ButtonManagers;
using System.Diagnostics;
using MyCalculatorConverter.Properties;

namespace MyСalculatorConverter.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields

        private IWindowFactory _windowFactory = new WindowFactory();

        private InputDataHandler _inputDataHandler;

        private string _operation;

        private ButtonManager _buttonManager;

        #endregion

        #region Ctors

        public MainViewModel()
        {
            GeneratingCommands();

            Display = new Display();
            Journal = new Journal();
            MainView = new MainSimpleCalculatorView();
            _inputDataHandler = new Calculator();
            _buttonManager = new EqualsEntered();

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
        public RelayCommand DotInputCommand { get; set; }
        public RelayCommand EqualsInputCommand { get; set; }

        public RelayCommand DeleteAllCommand { get; set; }
        public RelayCommand DeleteOneNumberCommand { get; set; }

        public RelayCommand JournalTextChoiceCommand { get; set; }

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
            if(_buttonManager.IsEqualsInput == true)
            {
                DeleteAll();
            }

            var text = parameter as string;
            Display.NumbersInput(text);

            _buttonManager.IsEqualsInput = false;
            _buttonManager.IsWorkingSymbalInput = false;
        }
        public bool CanExecuteNumbersInputCommand(object parameter)
        {
            return Display.InputText.Length < Int32.Parse(Resources.MaxCountSymbal);
        }

        private void ExecuteDotInputCommand(object parameter)
        {
            var text = parameter as string;
            if (Display.InputText.Length == 0)
            {
                Display.AddNumber("0");
            }
            Display.NumbersInput(text);

            _buttonManager = new DottInput();
        }
        public bool CanExecuteDotInputCommand(object parameter)
        {
            return ((_buttonManager.IsDotInput != true) & (Display.InputText.Length != 0));
        }

        #endregion

        #region SimpleCalculatorCommands

        private void ExecuteOperationInputCommand(object parameter)
        {
            if (Display.InputText.Length > 0)
            {
                _inputDataHandler.LeftNumber = Display.InputText;
            }
            _operation = parameter as string;
            WorkingSymbalInput(parameter as string);
        }
        public bool CanExecuteOperationInputCommand(object parameter)
        {
            return _buttonManager.IsWorkingSymbalInput != true; ;
        }
        
        private void ExecuteEqualsInputCommand(object parameter)
        {
            
            Journal.InputLeftPart(Display.OutputText);
            _inputDataHandler.RightNumber = Display.InputText;
            var text = _inputDataHandler.Calculation(_operation).ToString();
            Display.EqualsInput(text);
            Journal.InputRightPart(text);
            _inputDataHandler.LeftNumber = _inputDataHandler.Result;

            _buttonManager = new EqualsEntered();
        }
        public bool CanExecuteEqualsInputCommand(object parameter)
        {
            return (_buttonManager.IsEqualsInput != true || Display.InputText.Length != 0);
        }

        #endregion

        #region ManagementCommands

        private void ExecuteDeleteAllCommand(object parameter)
        {
            _inputDataHandler.LeftNumber = "";
            _inputDataHandler.RightNumber = "";
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

        private void ExecuteJournalTextChoiceCommand(object parametr)
        {
            var text = (parametr as string);
            Journal.RemoveNote(text);
            var index = text.IndexOf("=");
            Display.OutputText = text.Substring(0, (index + 1));
            _inputDataHandler.RightNumber = text.Substring((++index), text.Length - index);
            Display.InputText = text.Substring((++index), text.Length - index);
        }
        public bool CanExecuteJournalTextChoiceCommand(object parametr)
        {
            return Journal.TextList.Count != 0;
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
            DotInputCommand = new RelayCommand(ExecuteDotInputCommand, CanExecuteDotInputCommand);
            EqualsInputCommand = new RelayCommand(ExecuteEqualsInputCommand, CanExecuteEqualsInputCommand);

            DeleteAllCommand = new RelayCommand(ExecuteDeleteAllCommand, CanExecuteDeleteAllCommand);
            DeleteOneNumberCommand = new RelayCommand(ExecuteDeleteOneNumberCommand, CanExecuteDeleteOneNumberCommand);
            JournalTextChoiceCommand = new RelayCommand(ExecuteJournalTextChoiceCommand, CanExecuteJournalTextChoiceCommand);
        }


        private void WorkingSymbalInput(string text)
        {
            _buttonManager = new OperationSymbalInpyt();
            Display.WorkingSymbalInput(text);
        }

        public void DeleteAll()
        {
            Display.DeleteOutput();

            _inputDataHandler.RightNumber = "";
            _inputDataHandler.LeftNumber = "";
            _inputDataHandler.Result = "";

            _buttonManager = new EqualsEntered();
        }

        #endregion
    }
}
