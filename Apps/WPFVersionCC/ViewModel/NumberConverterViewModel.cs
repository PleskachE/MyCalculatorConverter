using Apps.WPFVersionCC.Infrastructure;
using Apps.WPFVersionCC.ViewModel.Abstraction;

using Bll.Executers;
using Bll.Executers.Abstractions;

using Common.extensions;
using Common.ViewManagement.Interfaces;

using MyCalculatorConverter.Properties;

using NumberSystemConverter.abstraction;

using System;
using System.Collections.Generic;
using System.Linq;

namespace MyCalculatorConverter.ViewModel
{
    public class NumberConverterViewModel : ViewModelBase
    {
        #region Fields

        private IExecuter _executor;
        private IButtonManager _buttonManager;

        #endregion

        #region Ctor

        public NumberConverterViewModel(IDisplay display, IJournal journal, IButtonManager buttonManager,
            IEnumerable<INumberConverter> converters)
        {
            Display        = display;
            Journal        = journal;
            Converters     = converters;
            _buttonManager = buttonManager;
            _executor      = new NumberConverter(CurrentConverter);

            GeneratingCommands();
            _buttonManager.EqualsEntered();
        }

        #endregion

        #region Properties

        private INumberConverter _currentConverter;
        public INumberConverter CurrentConverter
        {
            get
            {
                if (_currentConverter == null)
                {
                    _currentConverter = Converters.ElementAt(0);
                }
                return _currentConverter;
            }
            set
            {
                _currentConverter = value;
                _executor = new NumberConverter(CurrentConverter);
                OnPropertyChanged();
            }
        }

        public IEnumerable<INumberConverter> Converters { get; set; }

        public RelayCommand NumbersInputCommand      { get; set; }
        public RelayCommand DotInputCommand          { get; set; }
        public RelayCommand EqualsInputCommand       { get; set; }
        public RelayCommand DeleteAllCommand         { get; set; }
        public RelayCommand JournalTextChoiceCommand { get; set; }
        public RelayCommand JournalClearCommand      { get; set; }

        public IDisplay Display { get; set; }
        public IJournal Journal { get; set; }

        #endregion

        #region Commands

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
            if (!Display.InputText.Any())
            {
                Display.WorkingSymbalInput("0");
            }
            Display.NumbersInput(parameter as string);
            _buttonManager.DotEntered();
        }
        public bool CanExecuteDotInputCommand(object parameter)
        {
            return (_buttonManager.IsDotInput != true) & (Display.InputText.Any());
        }

        private void ExecuteEqualsInputCommand(object parameter)
        {
            var text = Display.InputText;
            var result = _executor.Calculation(text);
            Display.AddNumber(result);
            Journal.AddNote(text + "=" + result);
            _buttonManager.EqualsEntered();
            _buttonManager.IsDotInput = true;
        }
        public bool CanExecuteEqualsInputCommand(object parameter)
        {
            return (_buttonManager.IsEqualsInput != true
                                                || Display.InputText.Any());
        }

        private void ExecuteDeleteAllCommand(object parameter)
        {
            Display.DeleteOutput();
            _buttonManager.EqualsEntered();
        }
        public bool CanExecuteDeleteAllCommand(object parameter)
        {
            return Display.OutputText.Any();
        }

        private void ExecuteJournalTextChoiceCommand(object parametr)
        {
            Display.DeleteOutput();
            var text = (parametr as string);
            if (text != null)
            {
                var index = text.IndexOf("=");
                Display.AddNumber(text
                                .Substring((++index), text.Length - index)
                                .GetNumbersFromString());
            }

        }
        public bool CanExecuteJournalTextChoiceCommand(object parametr)
        {
            return Journal.TextList.Any();
        }

        private void ExecuteJournalClearCommand(object parametr)
        {
            Journal.TextList.Clear();
        }
        public bool CanExecuteJournalClearCommand(object parametr)
        {
            return Journal.TextList.Any();
        }

        #endregion

        #region Methods

        private void GeneratingCommands()
        {
            NumbersInputCommand      = new RelayCommand(ExecuteNumbersInputCommand, CanExecuteNumbersInputCommand);
            DotInputCommand          = new RelayCommand(ExecuteDotInputCommand, CanExecuteDotInputCommand);
            EqualsInputCommand       = new RelayCommand(ExecuteEqualsInputCommand, CanExecuteEqualsInputCommand);
            DeleteAllCommand         = new RelayCommand(ExecuteDeleteAllCommand, CanExecuteDeleteAllCommand);
            JournalTextChoiceCommand = new RelayCommand(ExecuteJournalTextChoiceCommand, CanExecuteJournalTextChoiceCommand);
            JournalClearCommand      = new RelayCommand(ExecuteJournalClearCommand, CanExecuteJournalClearCommand);
        }

        #endregion
    }
}
