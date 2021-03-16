using Bll.Executers;
using Bll.Executers.Abstractions;

using Apps.WPFVersionCC.View.UserControls;
using Apps.WPFVersionCC.Infrastructure;
using Apps.WPFVersionCC.ViewModel.Abstraction;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using MyCalculatorConverter.Properties;

using Common.ViewManagement.Interfaces;

using Algorithms.Interface;

namespace Apps.WPFVersionCC.ViewModel
{
    public class CalculatorViewModel : ViewModelBase
    {
        #region Fields

        private IButtonManager _buttonManager;

        private IExecuter      _executor;

        #endregion

        #region Ctors

        public CalculatorViewModel(IEnumerable<IAlgorithm> algorithms,
            IDisplay display, IJournal journal, IButtonManager buttonManager)
        {
            GeneratingCommands();

            Display        = display;
            Journal        = journal;
            Keyboard       = new SimpleCalculatorView();

            _algorithms    = algorithms;
            _buttonManager = buttonManager;
            _executor      = new Calculator(CurrentAlgorithm);

            _buttonManager.EqualsEntered();
            ChangeSizesWindow(Int32.Parse(Resources.MinHeightSimpleCalc), Int32.Parse(Resources.MinWidthSimpleCalc));
        }

        #endregion

        #region Properties

        private UserControl _keyboard = new UserControl();
        public UserControl Keyboard
        {
            get { return _keyboard; }
            set
            {
                _keyboard = value;
                OnPropertyChanged();
            }
        }

        public IDisplay Display { get; set; }
        public IJournal Journal { get; set; }

        private IEnumerable<IAlgorithm> _algorithms;
        public IEnumerable<IAlgorithm> Algorithms
        {
            get
            {
                return _algorithms;
            }
            set
            {
                _algorithms = value;
                OnPropertyChanged();
            }
        }
        private IAlgorithm _currentAlgorithm;
        public IAlgorithm CurrentAlgorithm
        {
            get
            {
                if(_currentAlgorithm == null)
                {
                    _currentAlgorithm = Algorithms.First();
                }
                return _currentAlgorithm;
            }
            set
            {
                _currentAlgorithm = value;
                _executor = new Calculator(CurrentAlgorithm);
                OnPropertyChanged();
            }
        }

        public RelayCommand NumbersInputCommand { get; set; }
        public RelayCommand OperationInputCommand { get; set; }
        public RelayCommand DotInputCommand { get; set; }
        public RelayCommand ParenthesisInputCommand { get; set; }
        public RelayCommand EqualsInputCommand { get; set; }
        public RelayCommand DeleteAllCommand { get; set; }
        public RelayCommand DeleteOneNumberCommand { get; set; }

        public RelayCommand JournalTextChoiceCommand { get; set; }
        public RelayCommand JournalClearCommand { get; set; }

        public RelayCommand ChangingTypeCalculatorCommand { get; set; }

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

            _buttonManager.DotEntered();
        }
        public bool CanExecuteDotInputCommand(object parameter)
        {
            return ((_buttonManager.IsDotInput != true) & (Display.InputText.Length != 0));
        }

        #endregion

        #region CalculatorCommands

        private void ExecuteOperationInputCommand(object parameter)
        {
            if (Display.InputText.Length == 0)
            {
                WorkingSymbalInput("0");
            }
            if ((parameter as string) == "1/")
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
            var result = _executor.Calculation(text).ToString();
            Display.EqualsInput(result);
            Journal.InputRightPart(result);
            Display.InputText = result;

            _buttonManager.EqualsEntered();
            _buttonManager.IsDotInput = true;
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
            _buttonManager.EqualsEntered();
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
            if (text != null)
            {
                var index = text.IndexOf("=");
                Display.AddNumber(text.Substring((++index), text.Length - index));
            }
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

        private void ExecuteChangingTypeCalculatorCommand(object parametr)
        {
            var text = parametr as string;
            switch (text)
            {
                case "Simple":
                    Keyboard = new SimpleCalculatorView();
                    ChangeSizesWindow(Int32.Parse(Resources.MinHeightSimpleCalc), Int32.Parse(Resources.MinWidthSimpleCalc));
                    break;
                case "Engineering":
                    Keyboard = new EngineeringCalculatorView();
                    ChangeSizesWindow(Int32.Parse(Resources.MinHeightEngineeringCalc), Int32.Parse(Resources.MinWidthEngineeringCalc));
                    break;
            }
        }
        public bool CanExecuteChangingTypeCalculatorCommand(object parametr)
        {
            return true;
        }

        #endregion

        #region Methods

        private void GeneratingCommands()
        {
            NumbersInputCommand = new RelayCommand(ExecuteNumbersInputCommand, CanExecuteNumbersInputCommand);

            OperationInputCommand         = new RelayCommand(ExecuteOperationInputCommand, CanExecuteOperationInputCommand);
            DotInputCommand               = new RelayCommand(ExecuteDotInputCommand, CanExecuteDotInputCommand);
            EqualsInputCommand            = new RelayCommand(ExecuteEqualsInputCommand, CanExecuteEqualsInputCommand);

            DeleteAllCommand              = new RelayCommand(ExecuteDeleteAllCommand, CanExecuteDeleteAllCommand);
            DeleteOneNumberCommand        = new RelayCommand(ExecuteDeleteOneNumberCommand, CanExecuteDeleteOneNumberCommand);
            JournalTextChoiceCommand      = new RelayCommand(ExecuteJournalTextChoiceCommand, CanExecuteJournalTextChoiceCommand);
            JournalClearCommand           = new RelayCommand(ExecuteJournalClearCommand, CanExecuteJournalClearCommand);

            ParenthesisInputCommand       = new RelayCommand(ExecuteParenthesisInputCommand, CanExecuteParenthesisInputCommand);

            ChangingTypeCalculatorCommand = new RelayCommand(ExecuteChangingTypeCalculatorCommand, CanExecuteChangingTypeCalculatorCommand);
        }


        private void WorkingSymbalInput(string text)
        {
            _buttonManager.WorkingSymbalEntered();
            Display.WorkingSymbalInput(text);
        }

        public void DeleteAll()
        {
            Display.DeleteOutput();
            _buttonManager.EqualsEntered();
        }

        private void ChangeSizesWindow(int minHeight, int minWidth)
        {
            Application.Current.MainWindow.Height    = minHeight;
            Application.Current.MainWindow.Width     = minWidth;
            Application.Current.MainWindow.MinHeight = minHeight;
            Application.Current.MainWindow.MinWidth  = minWidth;;
        }

        #endregion
    }
}
