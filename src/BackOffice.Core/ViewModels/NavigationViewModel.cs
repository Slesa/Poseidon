using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Core.Contracts;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class NavigationViewModel : INavigationViewModel
    {
        IRegionNavigationJournal _navigationJournal;

        public NavigationViewModel(IRegionManager regionManager)
        {
            var modules = regionManager.Regions[Regions.TagModulesRegion];
            modules.NavigationService.Navigated += OnNavigated;
            _navigationJournal = modules.NavigationService.Journal;
            //_navigationJournal = navigationJournal;
            
            //_navigationJournal = navigationJournal;
            OnBackCommand = new DelegateCommand(OnBack, CanGoBack);
            OnForwardCommand = new DelegateCommand(OnForward, CanGoForward);
        }

        void OnNavigated(object sender, RegionNavigationEventArgs e)
        {
            _navigationJournal = e.NavigationContext.NavigationService.Journal;
            ((DelegateCommand)OnBackCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)OnForwardCommand).RaiseCanExecuteChanged();
        }

        #region Commands

        public ICommand OnForwardCommand { get; private set; }

        void OnForward()
        {
        }

        bool CanGoForward()
        {
            return _navigationJournal.CanGoForward;
        }

        public ICommand OnBackCommand { get; private set; }

        void OnBack()
        {
        }

        bool CanGoBack()
        {
            return _navigationJournal.CanGoBack;
        }

        #endregion

        public string SearchText { get; set; }

    }
}