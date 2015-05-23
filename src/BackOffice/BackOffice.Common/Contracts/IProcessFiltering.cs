using System.Collections.Generic;

namespace Poseidon.BackOffice.Common.Contracts
{
    public interface IProcessFiltering
    {
        void SearchTermsChanged(IList<string> searchList);
    }
}