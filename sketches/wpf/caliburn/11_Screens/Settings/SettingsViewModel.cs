﻿using System.ComponentModel.Composition;
using Caliburn.Micro;
using _11_Screens.Framework;

namespace _11_Screens.Settings
{
    [Export(typeof(IWorkspace))]
    public class SettingsViewModel : Screen, IWorkspace 
    {
        public SettingsViewModel() 
        {
            DisplayName = IconName;
        }

        public string Icon 
        {
            get { return "../Settings/Resources/Images/report48.png"; }
        }

        public string IconName 
        {
            get { return "Settings"; }
        }

        public string Status 
        {
            get { return string.Empty; }
        }

        public void Show() 
        {
            ((IConductor)Parent).ActivateItem(this);
        }
    }
}