using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyCalculatorConverter.ViewManagment
{
    public class Display : INotifyPropertyChanged
    {
        public Display()
        {
            InputText = "";
            OutputText = "";
        }

        #region Properties

        private string _outputText;
        public string OutputText
        {
            get
            {
                return _outputText;
            }
            set
            {
                _outputText = value;
                OnPropertyChanged();
            }
        }

        private string _inputText;
        public string InputText
        {
            get
            {
                return _inputText;
            }
            set
            {
                _inputText = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #region Methods

        public void DeleteOutput()
        {
            InputText = "";
            OutputText = "";
        }

        public void NumbersInput(string text)
        {
            InputText += text;
            OutputText += text;
        }

        public void WorkingSymbalInput(string text)
        {
            InputText = "";
            OutputText += text;
        }

        public void EqualsInput(string text)
        {
            InputText = "";
            OutputText = text;
        }

        public void AddNumber(string text)
        {
            InputText = "";
            OutputText += text;
        }

        #endregion
    }
}
