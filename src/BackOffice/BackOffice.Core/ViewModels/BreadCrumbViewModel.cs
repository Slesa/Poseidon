using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Common.ViewModels;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class BreadCrumbViewModel : NotificationObject
    {
        readonly IRegionManager _regionManager;
        readonly IOfficeModule _homePage;

        IEnumerable<IOfficeModule> AvailableModules { get; set; }

        public BreadCrumbViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, IOfficeModule[] modules)
        {
            _regionManager = regionManager;
            eventAggregator.GetEvent<CurrentModuleChangedEvent>().Subscribe(UpdateBreadCrumbList);
            AvailableModules = modules;
            _homePage = CreateHomePage();
        }

        IEnumerable<ModuleViewModel> _currentModules;
        public IEnumerable<ModuleViewModel> CurrentModules
        {
            get { return _currentModules; }
            set
            {
                _currentModules = value;
                RaisePropertyChanged(() => CurrentModules);
            }
        }

        void UpdateBreadCrumbList(Uri modulePath)
        {
            var viewName = modulePath.OriginalString;
            var activeModule = AvailableModules.FirstOrDefault(m => m.ViewName == viewName);

            var currentModules = new List<IOfficeModule>();
            while (activeModule != null)
            {
                currentModules.Add(activeModule);
                var parentType = activeModule.ParentType;
                if (parentType == null) break;
                activeModule = AvailableModules.FirstOrDefault(m => m.GetType() == parentType);
            }
            currentModules.Add(_homePage);
            currentModules.Reverse();
            CurrentModules = currentModules.Select(x=>new ModuleViewModel(x, _regionManager));
        }

        static IOfficeModule CreateHomePage()
        {
            return new OfficeModule
                {
                    Title = "Home",
                    Description = "Go directly to the start page",
                };
        }
    }
}