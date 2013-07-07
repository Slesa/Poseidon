using System;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;
using Poseidon.Domain.Ums.Resources;

namespace Poseidon.BackOffice.Module.Ums.Modules
{
    public class UmsUserModule : IOfficeModule
    {
        public static readonly string Name = "UMS.UserModule";

        public IRegionManager RegionManager { get; set; }

        public UmsUserModule(IOfficeModule parent)
        {
            Parent = parent;
            SelectedCommand = new DelegateCommand(OnSelection);
        }

        public string Title { get { return "User list"; } }
        public string ToolTip { get { return "Manage your users"; } }
        public string IconFileName { get { return UmsResources.UserIcon; } }
        public int Priority { get { return 1; } }
        public IOfficeModule Parent { get ; private set; }

        public ICommand SelectedCommand { get; set; }

        void OnSelection()
        {
            //var moduleRegion = RegionManager.Regions[Regions.TagModulesRegion];
            //moduleRegion.RequestNavigate(new Uri("UmsModuleView", UriKind.Relative));
            MessageBox.Show("User Module selected");
        }
    }
}