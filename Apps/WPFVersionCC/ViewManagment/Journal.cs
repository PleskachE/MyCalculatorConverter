using System.Collections.ObjectModel;

namespace Apps.WPFVersionCC.ViewManagment
{
    public class Journal 
    {

        private string _text;

        public ObservableCollection<string> TextList { get; set; }

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

        public void AddNote(string text)
        {
            TextList.Add(text);
        }

        private void ClearText()
        {
            _text = "";
        }

    }
}
