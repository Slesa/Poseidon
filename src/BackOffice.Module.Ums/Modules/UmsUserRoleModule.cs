using Poseidon.BackOffice.Common;
using Poseidon.Domain.Ums.Resources;

namespace Poseidon.BackOffice.Module.Ums.Modules
{
    public class UmsUserRoleModule : IOfficeModule
    {
        public static readonly string Name = "UMS.UserRoleModule";

        public UmsUserRoleModule(IOfficeModule parent)
        {
            Parent = parent;
        }

        public string Title { get { return "User roles"; } }
        public string ToolTip { get { return "Manage your user roles"; } }
        public string IconFileName { get { return UmsResources.UserRoleIcon; } }
        public int Priority { get { return 2; } }
        public IOfficeModule Parent { get ; private set; }
    }
}