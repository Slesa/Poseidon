using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Common.Contracts;
using Poseidon.BackOffice.Common.ViewModels;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class ModulesViewModel : IProcessFiltering
    {
        public ModulesViewModel(IUnityContainer container, IRegionManager regionManager)
        {
            var modules = container.ResolveAll<IOfficeModule>().ToArray();
            Modules = modules.Where(x=>x.ParentType==null).OrderBy(x=>x.Priority).Select(x => new OfficeModuleViewModel(x, modules, regionManager));
        }

        IEnumerable<ModuleViewModel> Modules { get; set; }

        ICollectionView _modulesCollection;
        public ICollectionView ModulesCollection
        {
            get
            {
                if (_modulesCollection != null) return _modulesCollection;
                _modulesCollection = CollectionViewSource.GetDefaultView(Modules);
                _modulesCollection.SortDescriptions.Add(new SortDescription("Priority", ListSortDirection.Ascending));
                //_modulesCollection.GroupDescriptions.Add(new PropertyGroupDescription("Parent.Tile"));
                _modulesCollection.Filter = Filter;
                return _modulesCollection;
            }
        }

        bool Filter(object obj)
        {
            if (_searchList == null || !_searchList.Any()) return true;

            var module = obj as ModuleViewModel;
            if (module == null) return true;

            foreach (var searchTerm in _searchList)
            {
                if (module.Title.ToLower().Contains(searchTerm)) return true;
                if (module.Keywords.Any(x=> x.ToLower()==searchTerm)) return true;
            }
            return false;
        }

        IList<string> _searchList;
        public void SearchTermsChanged(IList<string> searchList)
        {
            _searchList = searchList.Select(x => x.ToLower()).ToList();
            ModulesCollection.Refresh();
        }
    }
}