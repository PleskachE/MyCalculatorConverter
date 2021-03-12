using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Models.Calculator.Abstraction
{
    public abstract class PartAlgorithm : INotifyPropertyChanged, IPartAlgorithm
    {

        private ICollectionChar _listOfReturn;
        public ICollectionChar ListOfReturn
        {
            get
            {
                return _listOfReturn;
            }
            set
            {
                _listOfReturn = value;
                OnPropertyChanged("ListOfReturn");
            }
        }

        private ICollectionChar _operationStack;
        public ICollectionChar OperationStack
        {
            get
            {
                return _operationStack;
            }
            set
            {
                _operationStack = value;
                OnPropertyChanged("OperationStack");
            }
        }

        public virtual void Processing(string symbal) { }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
