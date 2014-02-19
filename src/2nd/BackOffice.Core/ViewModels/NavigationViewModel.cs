using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Core.Contracts;
using Poseidon.BackOffice.Core.Services;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class NavigationViewModel : INavigationViewModel
    {
        readonly IRegionManager _regionManager;
        readonly INavigationService _navigationService;

        public NavigationViewModel(IRegionManager regionManager, INavigationService navigationService)
        {
            _regionManager = regionManager;
            _navigationService = navigationService;

            var modules = _regionManager.Regions[Regions.TagModulesRegion];
            modules.NavigationService.Navigated += OnNavigated;
            
            OnBackCommand = new DelegateCommand(OnBack, CanGoBack);
            OnForwardCommand = new DelegateCommand(OnForward, CanGoForward);
        }

        void OnNavigated(object sender, RegionNavigationEventArgs e)
        {
            _navigationService.ReportNavigation(e.Uri);
            ((DelegateCommand)OnBackCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)OnForwardCommand).RaiseCanExecuteChanged();
        }

        #region Commands

        public ICommand OnForwardCommand { get; private set; }

        void OnForward()
        {
            var uri = _navigationService.GoForwardOnePage();
            if (uri == null) return;
            _regionManager.RequestNavigate(Regions.TagModulesRegion, uri);
        }

        bool CanGoForward()
        {
            return _navigationService.CanGoForward;
        }

        public ICommand OnBackCommand { get; private set; }

        void OnBack()
        {
            var uri = _navigationService.GoBackOnePage();
            if( uri==null) return;
            _regionManager.RequestNavigate(Regions.TagModulesRegion, uri);
        }

        bool CanGoBack()
        {
            return _navigationService.CanGoBack;
        }

        #endregion

        public string SearchText { get; set; }

    }
}