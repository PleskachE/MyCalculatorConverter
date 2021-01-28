using Model.Common;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model.Abstraction
{
    public abstract class BaseOperation : INotifyPropertyChanged
    {
        private string _value;
        public string Value
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

        public Priority Priority { get; set; }

        public virtual string Result(string left, string right)
        {
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
