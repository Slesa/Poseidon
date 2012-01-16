using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using Persistence.Shared;

namespace BackOffice.Shared
{
    public abstract class SelectionListViewModel<T> : Screen
        where T : PropertyChangedBase, ISelectableRowViewModelBase
    {
        //[Import] // TODO: Importing would be nice
        protected IDbConversation DbConversation;
        //[Import] // TODO: Importing would be nice
        protected IEventAggregator EventAggregator { get; set; }
        public IObservableCollection<T> ElementList { get; set; }

        public bool ItemSelected
        {
            get { return ElementList.Where(element => element.IsSelected).Count() == 1 ? true : false; }
        }

        public bool ItemsSelected
        {
            get { return ElementList.FirstOrDefault(element => element.IsSelected) != null ? true : false; }
        }

        public bool CanEdit
        {
            get { return ItemsSelected; }
        }

        public bool CanRemove
        {
            get { return ItemsSelected; }
        }

        protected SelectionListViewModel(string caption)
        {
            DbConversation = IoC.Get<IDbConversation>();
            EventAggregator = IoC.Get<IEventAggregator>();
            DisplayName = caption;
            PrepareElementList();
        }

        protected abstract BindableCollection<T> CreateElementList();

        void PrepareElementList()
        {
            ElementList = CreateElementList();
            foreach(var element in ElementList)
                ConnectElement(element);
        }

        protected void ConnectElement(T element)
        {
            element.PropertyChanged += OnPropertyChanged;
        }

        void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "IsSelected")
                return;
            NotifyOfPropertyChange(() => CanEdit);
            NotifyOfPropertyChange(() => CanRemove);
        }
    }
}