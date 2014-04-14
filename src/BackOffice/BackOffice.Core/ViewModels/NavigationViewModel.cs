using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Common.Contracts;
using Poseidon.BackOffice.Core.Contracts;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class NavigationViewModel : NotificationObject
    {
        readonly IEventAggregator _eventAggregator;
        readonly IRegionManager _regionManager;
        readonly INavigationService _navigationService;

        public NavigationViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, INavigationService navigationService)
        {
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;
            _navigationService = navigationService;

            // Navigation is done within the modules region, so follow the navigation path there
            var modules = _regionManager.Regions[Regions.TagModulesRegion];
            modules.NavigationService.Navigated += OnNavigated;

            //OnHomeCommand = new DelegateCommand(GoHome, CanGoHome);
            OnBackCommand = new DelegateCommand(GoBack, CanGoBack);
            OnForwardCommand = new DelegateCommand(GoForward, CanGoForward);

        }

        string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                RaisePropertyChanged(()=>SearchText);

                var searchTerms = _searchText.Split(' ');

                var view = _regionManager.Regions[Regions.TagModulesRegion].ActiveViews.FirstOrDefault() as ContentControl;
                if (view == null) return;
                var filterProcessor = view.DataContext as IProcessFiltering;
                if (filterProcessor == null) return;
                filterProcessor.SearchTermsChanged(searchTerms);
            }
        }

        
        void OnNavigated(object sender, RegionNavigationEventArgs e)
        {
            SearchText = string.Empty;

            _navigationService.ReportNavigation(e.Uri);
            //((DelegateCommand)OnHomeCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)OnBackCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)OnForwardCommand).RaiseCanExecuteChanged();
        }

        #region Commands

/*
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
*/

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