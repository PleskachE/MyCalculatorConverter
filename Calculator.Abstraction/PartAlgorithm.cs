using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Models.Calculator.Abstraction
{
    public abstract class PartAlgorithm : INotifyPropertyChanged, IPartAlgorithm
    {

        private List<BaseSymbal> _listOfReturn = new List<BaseSymbal>();
        public List<BaseSymbal> ListOfReturn
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

        private List<BaseSymbal> _operationStack = new List<BaseSymbal>();
        public List<BaseSymbal> OperationStack
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
