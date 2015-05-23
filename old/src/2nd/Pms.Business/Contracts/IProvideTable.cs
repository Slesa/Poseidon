using Pms.Business.Models;

namespace Pms.Business.Contracts
{
    /// <summary>
    /// Contract to work with a tableId.
    /// </summary>
    public interface IProvideTable
    {
        PmsTable OpenTable(uint tableId, uint party);
        void CloseTable(PmsTable table);
    }
}