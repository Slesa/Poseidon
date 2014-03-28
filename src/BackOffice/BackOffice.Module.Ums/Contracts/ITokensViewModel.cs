using System.Collections.ObjectModel;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.Contracts
{
    public interface ITokensViewModel
    {
        ObservableCollection<Token> Tokens { get; }
    }
}