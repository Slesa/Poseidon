using System.ComponentModel;
using System.Linq;
using Caliburn.Micro;
using Persistence.Shared;

namespace BackOffice.Shared.ViewModels
{
    public abstract class SelectionListViewModel<T> : Screen
        where T : PropertyChangedBase, ISelectableRowViewModelBase
    {
        //[Import] // TODO: Importing would be nice
        protected IDbConversation DbConversation;
        //[Import] // TODO: Importing would be nice
        protected IEventAggregator EventAggregator { get; set; }

        IObservableCollection<T> _elementList;
        public IObservableCollection<T> ElementList { get { return _elementList ?? (_elementList = PrepareElementList()); } }


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
        }

        protected abstract BindableCollection<T> CreateElementList();

        IObservableCollection<T> PrepareElementList()
        {
            IObservableCollection<T> result = null;
            DbConversation.UsingTransaction(() => result = CreateElementList());
            foreach(var element in result)
                ConnectElement(element);
            return result;
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