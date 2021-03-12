using Apps.WPFVersionCC.Infrastructure;
using Apps.WPFVersionCC.Properties;
using Apps.WPFVersionCC.ViewModel.Abstraction;
using Bll.Executers;
using Bll.Executers.Abstractions;
using Common.extensions;
using Common.ViewManagement;
using Common.ViewManagement.Interfaces;
using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Entities;
using MyCalculatorConverter.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Apps.WPFVersionCC.ViewModel
{
    public class ValueConverterViewModel : ViewModelBase
    {
        #region Fields

        private IExecuter _executor;
        private IButtonManager _buttonManager;

        #endregion

        #region Ctor

        public ValueConverterViewModel()
        {
            GeneratingCommands();

            _buttonManager = new ButtonManager();
            _buttonManager.EqualsEntered();

            _executor = new ValueConverter(_currentSystem);

            Display = new Display();
            Journal = new Journal();
            Systems = new List<BaseSystem>()
            {
                new LengthSystem(),
                new WeightsSystem(),
                new MemorySystem()
            };
        }

        #endregion

        #region Properties

        private BaseSystem _currentSystem;
        public BaseSystem CurrentSystem
        {
            get 
            {
                if(_currentSystem == null)
                {
                    _currentSystem = Systems.ElementAt(0);
                }
                return _currentSystem; 
            }
            set
            {
                _currentSystem = value;
                CurrentResultUnit = CurrentFirstUnit = _currentSystem.GetReferenceUnit();                
                OnPropertyChanged();
            }
        }

        private IUnitSystem _currentFirstUnit;
        public IUnitSystem CurrentFirstUnit
        {
            get
            {
                if(_currentFirstUnit == null)
                {
                    _currentFirstUnit = CurrentSystem.GetReferenceUnit();
                }
                return _currentFirstUnit;
            }
            set
            {
                _currentFirstUnit = value;
                OnPropertyChanged();
            }
        }
        private IUnitSystem _currentResultUnit;
        public IUnitSystem CurrentResultUnit
        {
            get
            {
                if (_currentResultUnit == null)
                {
                    _currentResultUnit = CurrentSystem.GetReferenceUnit();
                }
                return _currentResultUnit;
            }
            set
            {
                _currentResultUnit = value;
                OnPropertyChanged();
            }
        }

        public ICollection<BaseSystem> Systems { get; }

        public RelayCommand NumbersInputCommand { get; set; }
        public RelayCommand DotInputCommand { get; set; }
        public RelayCommand EqualsInputCommand { get; set; }
        public RelayCommand DeleteAllCommand { get; set; }
        public RelayCommand JournalTextChoiceCommand { get; set; }
        public RelayCommand JournalClearCommand { get; set; }

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
            if (Display.InputText.Length == 0)
            {
                Display.WorkingSymbalInput("0");
            }
            Display.NumbersInput(parameter as string);

            _buttonManager.DotEntered();
        }
        public bool CanExecuteDotInputCommand(object parameter)
        {
            return (_buttonManager.IsDotInput != true) & (Display.InputText.Length != 0);
        }

        private void ExecuteEqualsInputCommand(object parameter)
        {
            var text = Display.InputText 
                                + CurrentFirstUnit.Name 
                                + "=" 
                                + CurrentResultUnit.Name;
            var result = _executor.Calculation(text);
            text = Display.InputText 
                    + CurrentFirstUnit.Name 
                    + "=" 
                    + result 
                    + CurrentResultUnit.Name;
            Display.AddNumber(result);
            Journal.AddNote(text);
            _buttonManager.EqualsEntered();
            _buttonManager.IsDotInput = true;
        }
        public bool CanExecuteEqualsInputCommand(object parameter)
        {
            return (_buttonManager.IsEqualsInput != true 
                                                || Display.InputText.Length != 0 
                                                || CurrentFirstUnit != null 
                                                || CurrentResultUnit != null);
        }

        private void ExecuteDeleteAllCommand(object parameter)
        {
            Display.DeleteOutput();
            _buttonManager.EqualsEntered();
        }
        public bool CanExecuteDeleteAllCommand(object parameter)
        {
            return Display.OutputText.Length != 0;
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
