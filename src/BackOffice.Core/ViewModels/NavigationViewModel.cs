using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Core.Contracts;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class NavigationViewModel : INavigationViewModel
    {
        readonly IRegionManager _regionManager;
        readonly List<Uri> _backStack = new List<Uri>();
        readonly List<Uri> _forwardStack = new List<Uri>();

        Uri _startPage;
        Uri StartPage { get { return _startPage ?? new Uri("ModulesView", UriKind.Relative); } }
        Uri _currentPage;
        Uri CurrentPage { get { return _currentPage ?? StartPage; } set { _currentPage = value; } }

        public NavigationViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            var modules = _regionManager.Regions[Regions.TagModulesRegion];
            modules.NavigationService.Navigated += OnNavigated;
            
            //_navigationJournal = navigationJournal;
            
            //_navigationJournal = navigationJournal;
            OnBackCommand = new DelegateCommand(OnBack, CanGoBack);
            OnForwardCommand = new DelegateCommand(OnForward, CanGoForward);
        }

        void OnNavigated(object sender, RegionNavigationEventArgs e)
        {
            if (e.Uri != StartPage)
            {
                _backStack.Add(CurrentPage);
                CurrentPage = e.Uri;
            }
            else
                CurrentPage = null;
            ((DelegateCommand)OnBackCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)OnForwardCommand).RaiseCanExecuteChanged();
        }

        #region Commands

        public ICommand OnForwardCommand { get; private set; }

        void OnForward()
        {
            if (!_forwardStack.Any()) return;
            var uri = _forwardStack.Take(1).FirstOrDefault();
            _forwardStack.RemoveAt(0);
            _regionManager.RequestNavigate(Regions.TagModulesRegion, uri);
        }

        bool CanGoForward()
        {
            return _forwardStack.Any();
        }

        public ICommand OnBackCommand { get; private set; }

        void OnBack()
        {
            if (!_backStack.Any()) return;
            var uri = _backStack.Take(1).FirstOrDefault();
            _backStack.RemoveAt(0);
            _forwardStack.Add(CurrentPage);
            _regionManager.RequestNavigate(Regions.TagModulesRegion, uri);
        }

        bool CanGoBack()
        {
            return _backStack.Any();
        }

        #endregion

        public string SearchText { get; set; }

    }
}