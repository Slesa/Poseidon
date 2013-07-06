using Poseidon.BackOffice.Common;
using Poseidon.Domain.Ums.Resources;

namespace Poseidon.BackOffice.Module.Ums.Modules
{
    public class UmsUserModule : IOfficeModule
    {
        public static readonly string Name = "UMS.UserModule";

        public UmsUserModule(IOfficeModule parent)
        {
            Parent = parent;
        }

        public string Title { get { return "User list"; } }
        public string ToolTip { get { return "Manage your users"; } }
        public string IconFileName { get { return UmsResources.UserIcon; } }
        public int Priority { get { return 1; } }
        public IOfficeModule Parent { get ; private set; }
    }
}