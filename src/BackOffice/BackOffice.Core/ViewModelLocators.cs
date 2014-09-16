using Poseidon.BackOffice.Core.ViewModels;
using Poseidon.Common.Wpf;

namespace Poseidon.BackOffice.Core
{
    public class StatusBarViewModelLocator : ViewModelLocator<StatusBarViewModel> { }
    public class NavigationViewModelLocator : ViewModelLocator<NavigationViewModel> { }
    public class ModulesViewModelLocator : ViewModelLocator<ModulesViewModel> { }
    public class BreadCrumbViewModelLocator : ViewModelLocator<BreadCrumbViewModel> { }

    public class LoginViewModelLocator : ViewModelLocator<LoginViewModel> { }
}