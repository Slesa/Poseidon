using System.Collections.Generic;
using Poseidon.BackOffice.Common;

namespace Poseidon.BackOffice.Core.Contracts
{
    public interface IModulesView
    {
        IEnumerable<IOfficeModule> Modules { get; }
    }
}