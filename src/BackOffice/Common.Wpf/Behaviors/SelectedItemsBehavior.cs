using System;
using System.Collections;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using Poseidon.Common.Wpf.Helpers;

namespace Poseidon.Common.Wpf.Behaviors
{
    public class SelectedItemsBehavior : Behavior<ListBox>
    {
        public static readonly DependencyProperty SelectionsProperty =
            DependencyProperty.Register(
                "Selections",
                typeof (IList),
                typeof (SelectedItemsBehavior),
                new PropertyMetadata(null, OnSelectionsPropertyChanged));

        bool _updating;
        WeakEventHandler<SelectedItemsBehavior, object, NotifyCollectionChangedEventArgs> _currentWeakHandler;

        public IList Selections
        {
            get { return (IList)GetValue(SelectionsProperty); }
            set { SetValue(SelectionsProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += OnSelectedItemsChanged;
            UpdateSelectedItems();
        }

        protected override void OnDetaching()
        {
            AssociatedObject.SelectionChanged -= OnSelectedItemsChanged;
            base.OnDetaching();
        }

        static void OnSelectionsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = d as SelectedItemsBehavior;
            if (behavior == null) return;

            if (behavior._currentWeakHandler != null)
            {
                behavior._currentWeakHandler.Detach();
                behavior._currentWeakHandler = null;
            }
            
            if (e.NewValue == null) return;

            var notifyCollectionChanged = e.NewValue as INotifyCollectionChanged;
            if (notifyCollectionChanged != null)
            {
                behavior._currentWeakHandler =
                    new WeakEventHandler<SelectedItemsBehavior, object, NotifyCollectionChangedEventArgs>(
                        behavior,
                        (instance, sender, args) => instance.OnSelectionsCollectionChanged(sender, args),
                        listener => notifyCollectionChanged.CollectionChanged -= listener.OnEvent);
                notifyCollectionChanged.CollectionChanged += behavior._currentWeakHandler.OnEvent;
            }
            behavior.UpdateSelectedItems();
        }

        void OnSelectedItemsChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelections(e);
        }


        void UpdateSelections(SelectionChangedEventArgs e)
        {
            ExecuteIfNotUpdating(() =>
                {
                    if (Selections != null)
                    {
                        foreach (var item in e.AddedItems)
                        {
                            Selections.Add(item);
                        }
                        foreach (var item in e.RemovedItems)
                        {
                            Selections.Remove(item);
                        }
                    }
                });
        }

        void OnSelectionsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateSelectedItems(e);
        }

        void UpdateSelectedItems()
        {
            ExecuteIfNotUpdating(() =>
                {
                    if (AssociatedObject != null)
                    {
                        AssociatedObject.SelectedItems.Clear();
                        foreach (var item in Selections ?? new object[0])
                        {
                            AssociatedObject.SelectedItems.Add(item);
                        }
                    }
                });
        }

        void UpdateSelectedItems(NotifyCollectionChangedEventArgs e)
        {
            ExecuteIfNotUpdating(() =>
                {
                    if (AssociatedObject != null)
                    {
                        if (e.Action == NotifyCollectionChangedAction.Reset)
                        {
                            AssociatedObject.SelectedItems.Clear();
                            return;
                        }
                        if (e.Action == NotifyCollectionChangedAction.Add)
                        {
                            foreach (var item in e.NewItems)
                            {
                                AssociatedObject.SelectedItems.Add(item);
                            }
                        }
                        if (e.Action == NotifyCollectionChangedAction.Remove)
                        {
                            foreach (var item in e.OldItems)
                            {
                                AssociatedObject.SelectedItems.Remove(item);
                            }
                        }
                    }
                });
        }

        void ExecuteIfNotUpdating(Action execute)
        {
            if (_updating) return;
            try
            {
                _updating = true;
                execute();
            }
            finally
            {
                _updating = false;
            }
        }
    }
}