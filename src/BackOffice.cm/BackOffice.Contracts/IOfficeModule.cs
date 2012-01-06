using Caliburn.Micro;

namespace BackOffice.Contracts
{
    public interface IOfficeModule : IScreen
    {
        string ModuleName { get; }
        string IconFileName { get; }
        string ToolTip { get; }
    }
}