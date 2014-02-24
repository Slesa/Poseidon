using System.ComponentModel;

namespace BackOffice.Core.Contracts
{
    public interface IStatusBarViewModel : INotifyPropertyChanged
    {
        string Message { get; } 
    }
}