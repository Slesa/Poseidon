using Pms.Business.Models;

namespace Pms.Business.Contracts
{
    /// <summary>
    /// Contract to register a workbench of a waiter to a PMS terminal.
    /// </summary>
    public interface IProvideWorkbenches
    {
        PmsWorkbench ClaimWorkbench(uint waiterId);
        void FreeWorkbench(PmsWorkbench workbench);
    }
}