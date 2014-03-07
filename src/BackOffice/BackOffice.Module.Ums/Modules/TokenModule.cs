using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ums.Resources;
using Poseidon.Ums.Domain.Resources;

namespace Poseidon.BackOffice.Module.Ums.Modules
{
    public class TokenModule : OfficeModule
    {
        public static readonly string Name = "UMS.TokenModule";

        public TokenModule(UmsOfficeModule parent)
        {
            Title = Strings.TokenModule;
            Description = Strings.TokenModule_Description;
            ToolTip = Strings.TokenModule_Tooltip;
            IconFileName = UmsResources.TokenIcon;
            Parent = parent;
        }
    }
}