
using System.Collections.Generic;

namespace Bll.Model.Abstraction
{
    public interface IPartAlgorithm
    {
        void Processing(string symbal);
        List<BaseSymbal> GetOperationStack();
        List<BaseSymbal> GetListOfReturn();
    }
}
