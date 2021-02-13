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
using Bll.DataHandlers.Abstractions;
using Bll.DataHandlers;

namespace MyСalculatorConverter.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields

        private IWindowFactory _windowFactory = new WindowFactory();

        public InputDataHandler InputDataHandler;

        private ButtonManager _buttonManager;

        #endregion

        #region Ctors

        public MainViewModel()
        {
            GeneratingCommands();

            Display = new Display();
            Journal = new Journal();

            MainView = new MainSimpleCalculatorView();
            Application.Current.MainWindow = MainView.ChangeWindow(Application.Current.MainWindow);

            InputDataHandler = new Calculator();
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

            InputDataHandler = new Calculator();
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

            InputDataHandler = new Calculator();
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
        public RelayCommand OperationsWithSingleNumberCommand { get; set; }

        public RelayCommand NumbersInputCommand { get; set; }

        public RelayCommand OperationInputCommand { get; set; }
        public RelayCommand DotInputCommand { get; set; }
        public RelayCommand EqualsInputCommand { get; set; }

        public RelayCommand DeleteAllCommand { get; set; }
        public RelayCommand DeleteOneNumberCommand { get; set; }

        public RelayCommand JournalTextChoiceCommand { get; set; }
        public RelayCommand JournalClearCommand { get; set; }

        public RelayCommand ParenthesisInputCommand { get; set; }

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
             Display.NumbersInput(parameter as string);

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
                Display.WorkingSymbalInput("0");
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
            if (Display.InputText.Length == 0)
            {
                WorkingSymbalInput("0");
            }
            if((parameter as string) == "1/")
            {
                Display.DeleteOutput();
            }
            WorkingSymbalInput(parameter as string);
        }
        public bool CanExecuteOperationInputCommand(object parameter)
        {
            return _buttonManager.IsWorkingSymbalInput != true; ;
        }
        
        private void ExecuteEqualsInputCommand(object parameter)
        {
            Journal.InputLeftPart(Display.OutputText);
            var text = Display.OutputText.Replace(" ", "");
            var result = InputDataHandler.Calculation(text).ToString();
            Display.EqualsInput(result);
            Journal.InputRightPart(result);
            Display.InputText = result;

            _buttonManager = new EqualsEntered();
        }
        public bool CanExecuteEqualsInputCommand(object parameter)
        {
            return (_buttonManager.IsEqualsInput != true || Display.InputText.Length != 0);
        }

        #endregion

        #region ParenthesisCommand

        private void ExecuteParenthesisInputCommand(object parameter)
        {
            if (_buttonManager.IsEqualsInput == true)
            {
                DeleteAll();
            }
            Display.NumbersInput(parameter as string);
        }

        public bool CanExecuteParenthesisInputCommand(object parameter)
        {
            return true;
        }

        #endregion

        #region ManagementCommands

        private void ExecuteDeleteAllCommand(object parameter)
        {
            Display.DeleteOutput();
            _buttonManager = new EqualsEntered();
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
            Display.DeleteOutput();
            var text = (parametr as string);
            Journal.RemoveNote(text);
            var index = text.IndexOf("=");
            Display.AddNumber(text.Substring((++index), text.Length - index));
        }
        public bool CanExecuteJournalTextChoiceCommand(object parametr)
        {
            return Journal.TextList.Count != 0;
        }

        private void ExecuteJournalClearCommand(object parametr)
        {
            Journal.TextList.Clear();
        }
        public bool CanExecuteJournalClearCommand(object parametr)
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
            JournalClearCommand = new RelayCommand(ExecuteJournalClearCommand, CanExecuteJournalClearCommand);

            ParenthesisInputCommand = new RelayCommand(ExecuteParenthesisInputCommand, CanExecuteParenthesisInputCommand);
        }


        private void WorkingSymbalInput(string text)
        {
            _buttonManager = new OperationSymbalInpyt();
            Display.WorkingSymbalInput(text);
        }

        public void DeleteAll()
        {
            Display.DeleteOutput();
            _buttonManager = new EqualsEntered();
        }

        #endregion
    }
}
