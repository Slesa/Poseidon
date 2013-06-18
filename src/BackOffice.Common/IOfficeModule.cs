namespace Poseidon.BackOffice.Common
{
    public interface IOfficeModule
    {
        string Title { get; }
        string ToolTip { get; }
        string IconFileName { get; }
        IOfficeModule Parent { get; }
        
    }
}