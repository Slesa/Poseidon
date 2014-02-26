using System.ComponentModel;

namespace Poseidon.BackOffice.Core.Contracts
{
    public interface IStatusBarViewModel : INotifyPropertyChanged
    {
        string Message { get; } 
    }
}