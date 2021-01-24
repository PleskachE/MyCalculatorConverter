using System.Collections;
using System.Collections.ObjectModel;

namespace MyCalculatorConverter.ViewManagment
{
    public class Journal 
    {

        private string _text;

        public IList TextList { get; set; }

        public Journal()
        {
            TextList = new ObservableCollection<string>();
        }

        public void InputLeftPart(string text)
        {
            _text += "\n" + text;
        }

        public void InputRightPart(string text)
        {
            _text += " = " + text;
            TextList.Add(_text);
            ClearText();
        }

        private void ClearText()
        {
            _text = "";
        }

    }
}
