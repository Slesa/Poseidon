using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Common.ViewModels;
using Poseidon.BackOffice.Core.Resources;
using WPFLocalizeExtension.Extensions;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class BreadCrumbViewModel : BindableBase
    {
        readonly IRegionManager _regionManager;
        readonly IOfficeModule _homePage;

        IEnumerable<IOfficeModule> AvailableModules { get; set; }

        public BreadCrumbViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, IOfficeModule[] modules)
        {
            _regionManager = regionManager;
            eventAggregator.GetEvent<CurrentModuleUriChangedEvent>().Subscribe(UpdateBreadCrumbList);
            AvailableModules = modules;
            _homePage = CreateHomePage();

            UpdateBreadCrumbList(null);
        }

        IEnumerable<ModuleViewModel> _currentModules;
        public IEnumerable<ModuleViewModel> CurrentModules
        {
            get { return _currentModules; }
            set
            {
                _currentModules = value;
                OnPropertyChanged(() => CurrentModules);
            }
        }

        void UpdateBreadCrumbList(Uri targetUri)
        {
            var currentModules = new List<IOfficeModule>();
            if (targetUri != null)
            {
                var activeModule = AvailableModules.FirstOrDefault(m => m.TargetUri == targetUri);

                while (activeModule != null)
                {
                    currentModules.Add(activeModule);
                    var parentType = activeModule.ParentType;
                    if (parentType == null) break;
                    activeModule = AvailableModules.FirstOrDefault(m => m.GetType() == parentType);
                }
            }
            currentModules.Add(_homePage);
            currentModules.Reverse();
            CurrentModules = currentModules.Select(x=>new ModuleViewModel(x, _regionManager));
        }

        static IOfficeModule CreateHomePage()
        {
            return new OfficeModule
                {
                    Title = LocExtension.GetLocalizedValue<string>("CoreModule_Title"),
                    Description = LocExtension.GetLocalizedValue<string>("CoreModule_Description"),
                    ToolTip = LocExtension.GetLocalizedValue<string>("CoreModule_Tooltip"),
                    TargetUri = new Uri(CoreViews.ModulesView, UriKind.Relative),
                };
        }
    }
}