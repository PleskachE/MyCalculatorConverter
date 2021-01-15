using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ViewManagementLibrary.Abstractions
{
    public abstract class MainView : IMainView, INotifyPropertyChanged
    {

        #region Property

        private SizeToContent _sizeToContent;
        public SizeToContent SizeToContent
        {
            get
            {
                return _sizeToContent;
            }
            set
            {
                _sizeToContent = value;
                OnPropertyChanged("SizeToContent");
            }
        }

        private int _minHeightWindow;
        public int MinHeightWindow
        {
            get
            {
                return _minHeightWindow;
            }
            set
            {
                _minHeightWindow = value;
                OnPropertyChanged("MinHeightWindow");
            }
        }

        private int _minWidthWindow;
        public int MinWidthWindow
        {
            get
            {
                return _minWidthWindow;
            }
            set
            {
                _minWidthWindow = value;
                OnPropertyChanged("MinWidthWindow");
            }
        }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        #endregion

        public virtual Window ChangeWindow(Window window) 
        {
            return window;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
