using System.ComponentModel.Composition;
using Caliburn.Micro;
using Ums.OfficeModule.Resources;
using Ums.OfficeModule.ViewModels;

namespace Ums.OfficeModule
{
    [Export(typeof(IUmsModuleItem))]
    public class UsersModuleItem : IUmsModuleItem
    {
        [Import(typeof (ListUsersViewModel))] ListUsersViewModel _viewModel;

        public string ItemName { get { return Strings.UsersItemName; } }
        public string ToolTip { get { return Strings.UsersItemToolTip; } }
        public string IconFileName { get { return @"/Ums.Resources;component/User.png"; } }
        public IScreen RelatedView { get { return _viewModel; } }
    }
}