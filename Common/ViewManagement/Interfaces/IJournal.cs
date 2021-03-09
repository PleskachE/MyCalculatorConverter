using System.Collections.Generic;

namespace Common.ViewManagement.Interfaces
{
    public interface IJournal
    {
        ICollection<string> TextList { get; set; }
        void InputLeftPart(string text);
        void InputRightPart(string text);
        void AddNote(string text);
    }
}
