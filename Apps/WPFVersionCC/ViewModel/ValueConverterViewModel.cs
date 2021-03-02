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
        private BaseUnitSystem _currentResulttUnit;
        public BaseUnitSystem CurrentResulttUnit
        {
            get
            {
                if (_currentResulttUnit == null)
                {
                    _currentResulttUnit = CurrentSystem.GetReferenceUnit();
                }
                return _currentResulttUnit;
            }
            set
            {
                _currentResulttUnit = value;
                OnPropertyChanged();
            }
        }

        public ICollection<BaseSystem> Systems { get; }

        public Display Display { get; set; }
        public Journal Journal { get; set; }

        #endregion

        #region Commands

        #endregion

        #region Methods

        #endregion
    }
}
