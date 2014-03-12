using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Common.ViewModels;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class BreadCrumbViewModel : NotificationObject
    {
        [Dependency]
        public IEnumerable<ModuleViewModel> AvailableModules { get; set; }

        public BreadCrumbViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<CurrentModuleChangedEvent>().Subscribe(UpdateBreadCrumbList);
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
            
            var currentModules = new List<ModuleViewModel>();
            while (activeModule != null)
            {
                currentModules.Add(activeModule);
                var parentView = activeModule.ViewName;
                if (parentView == null) break;
                activeModule = AvailableModules.FirstOrDefault(m => m.ViewName == parentView);
                //parent = (IOfficeModule) _container.Resolve(type);
            }
            CurrentModules = currentModules;
        }
    }
}