using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyСalculatorConverter.Model
{
    public class Number : INotifyPropertyChanged
    {
        private double _value;

        public Number() { _value = 0; }

        public Number(double value)
        {
            _value = value;
        }

        public double Value
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

        #region operators
        public static Number operator +(Number x, Number y)
        {
            return new Number { Value = x.Value + y.Value };
        }

        public static Number operator -(Number x, Number y)
        {
            return new Number { Value = x.Value - y.Value };
        }

        public static Number operator *(Number x, Number y)
        {
            return new Number { Value = x.Value * y.Value };
        }

        public static Number operator /(Number x, Number y)
        {
            return new Number { Value = x.Value / y.Value };
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
