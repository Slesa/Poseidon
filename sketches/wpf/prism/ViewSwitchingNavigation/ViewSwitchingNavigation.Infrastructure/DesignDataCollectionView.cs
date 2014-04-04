using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ViewSwitchingNavigation.Infrastructure
{
    public class DesignDataCollectionView : Collection<object>, ICollectionView
    {
        public bool CanFilter { get { return false; } }
        public bool CanGroup { get { return false; } }
        public bool CanSort { get { return false; } }

        public System.Globalization.CultureInfo Culture 
        {
            get { return null; }
            set { throw new NotImplementedException(); }
        }

#pragma warning disable 67
        // Implements ICollectionView and is here only to support design-time data only.
        // It's no surprise no one actually uses these events
        public event EventHandler CurrentChanged;

        public event CurrentChangingEventHandler CurrentChanging;
#pragma warning restore 67

        public object CurrentItem { get { return null; } }
        public int CurrentPosition { get { return 0; } }
        public IDisposable DeferRefresh() { throw new NotImplementedException(); }

        public Predicate<object> Filter
        {
            get { return null; } 
            set { throw new NotImplementedException(); }
        }

        public ObservableCollection<GroupDescription> GroupDescriptions
        {
            get { return new ObservableCollection<GroupDescription>(); }
        }

        public ReadOnlyObservableCollection<object> Groups
        {
            get { return null; }
        }

        public bool IsCurrentAfterLast
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsCurrentBeforeFirst
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsEmpty
        {
            get { return false; }
        }

        public bool MoveCurrentTo(object item)
        {
            throw new NotImplementedException();
        }

        public bool MoveCurrentToFirst()
        {
            throw new NotImplementedException();
        }

        public bool MoveCurrentToLast()
        {
            throw new NotImplementedException();
        }

        public bool MoveCurrentToNext()
        {
            throw new NotImplementedException();
        }

        public bool MoveCurrentToPosition(int position)
        {
            throw new NotImplementedException();
        }

        public bool MoveCurrentToPrevious()
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
        }

        public SortDescriptionCollection SortDescriptions
        {
            get { return null; }
        }

        public System.Collections.IEnumerable SourceCollection
        {
            get { return null; }
        }

#pragma warning disable 67
        // Implements ICollectionView and is here only to support design-time data only.
        // It's no surprise no one actually uses this event.
        public event System.Collections.Specialized.NotifyCollectionChangedEventHandler CollectionChanged;
#pragma warning restore 67
    }
}