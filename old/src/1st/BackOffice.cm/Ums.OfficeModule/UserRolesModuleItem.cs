using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Ums.OfficeModule.Resources;
using Ums.OfficeModule.ViewModels;

namespace Ums.OfficeModule
{
    [Export(typeof(IUmsModuleItem))]
    public class UserRolesModuleItem : IUmsModuleItem
    {
        [Import(typeof(ListUserRolesViewModel))]
        ListUserRolesViewModel _viewModel;

        public string ItemName { get { return Strings.UserRolesItemName; } }
        public string ToolTip { get { return Strings.UserRolesItemToolTip; } }
        public string IconFileName { get { return @"/Ums.Resources;component/UserRole.png"; } }
        public IEnumerable<string> Keywords
        {
            get
            {
                yield return Strings.KeyRoles;
                yield return Strings.KeyRole;
                yield return Strings.KeyUsers;
                yield return Strings.KeyUser;
            }
        }
        public IScreen RelatedView { get { return _viewModel; } }
    }
}