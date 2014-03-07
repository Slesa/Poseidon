using System;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Core.Contracts;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class NavigationViewModel
    {
        readonly IRegionManager _regionManager;
        readonly INavigationService _navigationService;

        public NavigationViewModel(IRegionManager regionManager, INavigationService navigationService)
        {
            _regionManager = regionManager;
            _navigationService = navigationService;

            // Navigation is done within the modules region, so follow the navigation path there
            var modules = _regionManager.Regions[Regions.TagModulesRegion];
            modules.NavigationService.Navigated += OnNavigated;

            OnHomeCommand = new DelegateCommand(GoHome, CanGoHome);
            OnBackCommand = new DelegateCommand(GoBack, CanGoBack);
            OnForwardCommand = new DelegateCommand(GoForward, CanGoForward);
        }

        void OnNavigated(object sender, RegionNavigationEventArgs e)
        {
            _navigationService.ReportNavigation(e.Uri);
            ((DelegateCommand)OnHomeCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)OnBackCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)OnForwardCommand).RaiseCanExecuteChanged();
        }

        public string SearchText { get; set; }

        #region Commands

        public ICommand OnHomeCommand { get; private set; }

        void GoHome()
        {
            var uri = _navigationService.GoHome();
            if (uri == null) return;
            _regionManager.RequestNavigate(Regions.TagModulesRegion, uri);
        }

        bool CanGoHome()
        {
            return _navigationService.CanGoHome;
        }

        public ICommand OnForwardCommand { get; private set; }

        void GoForward()
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

        void GoBack()
        {
            var uri = _navigationService.GoBackOnePage();
            if (uri == null) return;
            _regionManager.RequestNavigate(Regions.TagModulesRegion, uri);
        }

        bool CanGoBack()
        {
            return _navigationService.CanGoBack;
        }

        #endregion

    }
}