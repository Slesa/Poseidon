using System.Collections.Generic;

namespace Poseidon.Backoffice.Shared.Contracts
{
    public interface IOfficeGroup
    {
        string Name { get; }
        string ImageFilename { get; }
        string ToolTip { get; }
        IEnumerable<IOfficeGroupItem> GroupItems { get; }
    }
}