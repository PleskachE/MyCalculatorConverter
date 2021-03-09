using Common.ViewManagement.Interfaces;

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Common.ViewManagement
{
    public class Journal : IJournal
    {
        private string _text;

        public ICollection<string> TextList { get; set; }

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
