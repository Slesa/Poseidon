using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.Events;
using Poseidon.BackOffice.Common;
using Poseidon.BackOffice.Core.Contracts;

namespace Poseidon.BackOffice.Core.Services
{
    public class NavigationService : INavigationService
    {
        readonly IEventAggregator _eventAggregator;
        readonly Stack<Uri> _backStack = new Stack<Uri>();
        readonly Stack<Uri> _forwardStack = new Stack<Uri>();
        
        bool _stackInvolved;

        public NavigationService(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public void ReportNavigation(Uri uri)
        {
            if (uri != StartPage)
            {
                if (!_stackInvolved) _forwardStack.Clear();
                _backStack.Push(CurrentPage);
                CurrentPage = uri;
            }
            else
            {
                CurrentPage = null;
            }
            _stackInvolved = false;

            if (_eventAggregator!=null) _eventAggregator.GetEvent<CurrentModuleChangedEvent>().Publish(uri);
        }

        Uri _startPage;
        public Uri StartPage { get { return _startPage ?? (_startPage = new Uri(CoreViews.ModulesView, UriKind.Relative)); } }

        Uri _currentPage;
        public Uri CurrentPage { get { return _currentPage ?? StartPage; } internal set { _currentPage = value; } }

        public Uri GoHome()
        {
            var uri = StartPage;
            //_forwardStack.Push(CurrentPage);
            //_stackInvolved = true;
            return uri;
        }

        public bool CanGoHome
        {
            get { return CurrentPage != StartPage; }
        }

        public Uri GoBackOnePage()
        {
            if (!_backStack.Any()) return null;
            var uri = _backStack.Pop();
            _forwardStack.Push(CurrentPage);
            _stackInvolved = true;
            return uri;
        }

        public bool CanGoBack
        {
            get { return _backStack.Any(); }
        }

        public Uri GoForwardOnePage()
        {
            if (!_forwardStack.Any()) return null;
            var uri = _forwardStack.Pop();
            _stackInvolved = true;
            return uri;
        }

        public bool CanGoForward
        {
            get { return _forwardStack.Any(); }
        }
    }
}