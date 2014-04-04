using ViewSwitchingNavigation.Email.ViewModels;
using ViewSwitchingNavigation.Infrastructure;

namespace ViewSwitchingNavigation.Email
{
    public class EmailNavigationItemViewModelLocator : ViewModelLocator<EmailNavigationItemViewModel> { }
    public class InboxViewModelLocator : ViewModelLocator<InboxViewModel> { }
    public class ComposeEmailViewModelLocator : ViewModelLocator<ComposeEmailViewModel> { }
}