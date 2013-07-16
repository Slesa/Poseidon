using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Module.Ics.Resources;
using Poseidon.Domain.Ics.Resources;

namespace Poseidon.BackOffice.Module.Ics.Modules
{
    public class RecipeModule : IOfficeModule
    {
        public static readonly string Name = "ICS.RecipeModule";

        public RecipeModule(IcsOfficeModule parent)
        {
            Parent = parent;
        }

        public string Title { get { return Strings.RecipeModule; } }
        public string ToolTip { get { return Strings.RecipeModuleTooltip; } }
        public string IconFileName { get { return IcsResources.RecipeIcon; } }
        public int Priority { get { return 90; } }
        public IOfficeModule Parent { get ; private set; }
    }
}