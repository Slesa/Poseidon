using System;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ums.Resources;
using Poseidon.Ums.Domain.Resources;

namespace Poseidon.BackOffice.Module.Ums.Modules
{
    public class TokenModule : OfficeModule
    {
        public static readonly string Name = "TokensView";

        public TokenModule()
        {
            Title = Strings.TokenModule;
            Description = Strings.TokenModule_Description;
            ToolTip = Strings.TokenModule_Tooltip;
            Priority = 0;
            IconFileName = UmsResources.TokenIcon;
            TargetUri = new Uri(UmsViews.TokensView, UriKind.Relative);
            ParentType = typeof(UmsOfficeModule);
        }
    }
}