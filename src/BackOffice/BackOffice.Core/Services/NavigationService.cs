using System;
using System.Collections.Generic;
using System.Linq;
using Poseidon.BackOffice.Core.Contracts;

namespace Poseidon.BackOffice.Core.Services
{
    public class NavigationService : INavigationService
    {
        readonly Stack<Uri> _backStack = new Stack<Uri>();
        readonly Stack<Uri> _forwardStack = new Stack<Uri>();

        public void ReportNavigation(Uri uri)
        {
            if (uri != StartPage)
            {
                _backStack.Push(CurrentPage);
                CurrentPage = uri;
            }
            else
            {
                //_forwardStack.Clear();
                CurrentPage = null;
            }
        }

        Uri _startPage;
        internal Uri StartPage { get { return _startPage ?? (_startPage = new Uri("Module", UriKind.Relative)); } }

        Uri _currentPage;
        internal Uri CurrentPage { get { return _currentPage ?? StartPage; } set { _currentPage = value; } }

        public Uri GoBackOnePage()
        {
            if (!_backStack.Any()) return null;
            var uri = _backStack.Pop();
            _forwardStack.Push(CurrentPage);
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
            return uri;
        }

        public bool CanGoForward
        {
            get { return _forwardStack.Any(); }
        }
    }
}