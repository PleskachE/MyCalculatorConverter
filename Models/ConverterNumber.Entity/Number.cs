using Models.ConverterNumber.Abstraction;
using NLog;
using System.ComponentModel;

using System.Runtime.CompilerServices;

namespace Models.ConverterNumber.Entity
{
    public class Number : INumber, INotifyPropertyChanged
    {
        #region Fields

        private Logger _logger;
        private decimal _value;

        #endregion

        #region Propertyes
        public decimal Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }

        #endregion

        #region Ctors

        public Number()
        {
            _logger = LogManager.GetCurrentClassLogger();
            Value = 0;
        }
        public Number(decimal value)
        {
            _logger = LogManager.GetCurrentClassLogger();
            Value = value;
        }
        public Number(int value)
        {
            _logger = LogManager.GetCurrentClassLogger();
            Value = value;
        }
        public Number(string value)
        {
            _logger = LogManager.GetCurrentClassLogger();
            decimal tempValue = 0;
            var isChecked = decimal.TryParse(value, out tempValue);
            if (isChecked == false)
            {
                _logger.Warn("string value not parse!");
            }
            Value = tempValue;
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
