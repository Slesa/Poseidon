using Caliburn.Micro;

namespace _11_Screens.Framework {
    public interface IShell : IConductor, IGuardClose {
        IDialogManager Dialogs { get; }
    }
}