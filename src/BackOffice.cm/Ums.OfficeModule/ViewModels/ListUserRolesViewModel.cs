﻿using System.ComponentModel.Composition;
using Caliburn.Micro;
using Ums.OfficeModule.Resources;

namespace Ums.OfficeModule.ViewModels
{
    [Export(typeof(IUmsModuleItem))]
    public class UserRolesModuleItem : IUmsModuleItem
    {
        [Import(typeof(ListUserRolesViewModel))]
        ListUserRolesViewModel _viewModel;

        public string ItemName { get { return Strings.UserRolesItemName; } }
        public string ToolTip { get { return Strings.UserRolesItemToolTip; } }
        public string IconFileName { get { return @"/Ums.Resources;component/UserRole.png"; } }
        public IScreen RelatedView { get { return _viewModel; } }
        
    }

    [Export(typeof(ListUserRolesViewModel))]
    public class ListUserRolesViewModel : Screen
    {
    }
}