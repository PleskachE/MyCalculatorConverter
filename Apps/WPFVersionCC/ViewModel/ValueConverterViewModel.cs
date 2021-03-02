using Apps.WPFVersionCC.Infrastructure;
using Apps.WPFVersionCC.ViewManagment;
using Apps.WPFVersionCC.ViewModel.Abstraction;
using Bll.Executers;
using Bll.Executers.Abstractions;
using Models.ConverterModels.Abstraction;
using Models.ConverterModels.Entities;
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

        #endregion

        #region Ctor

        public ValueConverterViewModel()
        {
            _executor = new ConverterUnitsMeasurement(_currentSystem);
            Systems = new List<BaseSystem>()
            {
                new LengthSystem(),
                new WeightsSystem(),
                new MemorySystem()
            };
            ConvertCommand = new RelayCommand(ExecuteConvertCommand, CanExecuteConvertCommand);
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
                OnPropertyChanged();
            }
        }

        private BaseUnitSystem _currentFirstUnit;
        public BaseUnitSystem CurrentFirstUnit
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
        private BaseUnitSystem _currentResultUnit;
        public BaseUnitSystem CurrentResultUnit
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

        private string _currentFirstUnitText;
        public string CurrentFirstUnitText
        {
            get
            {
                if (_currentFirstUnitText == null)
                {
                    _currentFirstUnitText = "0";
                }
                return _currentFirstUnitText;
            }
            set
            {
                _currentFirstUnitText = value;
                OnPropertyChanged();
            }
        }
        private string _currentResultUnitText;
        public string CurrentResultUnitText
        {
            get
            {
                if (_currentResultUnitText == null)
                {
                    _currentResultUnitText = "0";
                }
                return _currentResultUnitText;
            }
            set
            {
                _currentResultUnitText = value;
                OnPropertyChanged();
            }
        }

        private string _resultText;
        public string ResultText
        {
            get
            {
                if (_resultText == null)
                {
                    _resultText = "";
                }
                return _resultText;
            }
            set
            {
                _resultText = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand ConvertCommand { get; set; }

        #endregion

        #region Commands

        private void ExecuteConvertCommand(object parameter)
        {
            var text = CurrentFirstUnitText + CurrentFirstUnit.Name + "=" + CurrentResultUnit.Name;
            ResultText = _executor.Calculation(text);
        }

        public bool CanExecuteConvertCommand(object parameter)
        {
            return true;
        }

        #endregion

        #region Methods

        #endregion
    }
}
