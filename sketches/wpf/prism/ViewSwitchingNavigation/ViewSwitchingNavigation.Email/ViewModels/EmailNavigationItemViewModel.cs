﻿using System;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using ViewSwitchingNavigation.Infrastructure;

namespace ViewSwitchingNavigation.Email.ViewModels
{
    public class EmailNavigationItemViewModel
    {
        readonly IRegionManager _regionManager;
        public static Uri EmailsViewUri = new Uri("/InboxView", UriKind.Relative);
        Uri _lastUri;


        public EmailNavigationItemViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            OnClickCommand = new DelegateCommand(OnClick, CanClick);

            var mainContentRegion = _regionManager.Regions[RegionNames.MainContentRegion];
            if (mainContentRegion != null && mainContentRegion.NavigationService != null)
            {
                mainContentRegion.NavigationService.Navigated += MainContentRegion_Navigated;
            }
        }

        public void MainContentRegion_Navigated(object sender, RegionNavigationEventArgs e)
        {
            _lastUri = e.Uri;
            OnClickCommand.RaiseCanExecuteChanged();
        }

        #region Commands

        public DelegateCommand OnClickCommand { get; private set; }

        void OnClick()
        {
            _regionManager.RequestNavigate(RegionNames.MainContentRegion, EmailsViewUri);
        }

        bool CanClick()
        {
            return (_lastUri == EmailsViewUri);
        }

        #endregion
    }
}