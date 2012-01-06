using System.ComponentModel.Composition;
using BackOffice.Contracts;
using Caliburn.Micro;
using Ums.OfficeModule.Resources;

namespace Ums.OfficeModule.ViewModel
{
    [Export(typeof(IOfficeModule))]
    public class ListUsersViewModel : Screen, IOfficeModule
    {
        #region OfficeModule

        public string ModuleName { get { return Strings.UsersModule; } }
        public string ToolTip { get { return Strings.UsersModuleToolTip; } }
        public string IconFileName { get { return @"/Ums.Resources;component/Ums.png"; } }

        #endregion
    }
}