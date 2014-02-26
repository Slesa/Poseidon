using Poseidon.BackOffice.Core.Contracts;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class NavigationViewModel
    {
        readonly INavigationService _navigationService;

        public NavigationViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public string SearchText { get; set; }

        #region Commands

        public void GoForward()
        {
            var uri = _navigationService.GoForwardOnePage();
            if (uri == null) return;
            //_regionManager.RequestNavigate(Regions.TagModulesRegion, uri);
        }

        public bool CanGoForward()
        {
            return _navigationService.CanGoForward;
        }

        public void GoBack()
        {
            var uri = _navigationService.GoBackOnePage();
            if (uri == null) return;
            //_regionManager.RequestNavigate(Regions.TagModulesRegion, uri);
        }

        public bool CanGoBack()
        {
            return _navigationService.CanGoBack;
        }

        #endregion

    }
}