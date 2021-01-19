using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyCalculatorConverter.ViewManagment
{
    public class Journal : INotifyPropertyChanged
    {

        private string _text;
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void InputLeftPart(string text)
        {
            Text += "\n" + text;
        }

        public void InputRightPart(string text)
        {
            Text += " = " + text;
        }

    }
}
