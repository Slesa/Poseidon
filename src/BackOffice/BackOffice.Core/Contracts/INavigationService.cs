using System;

namespace Poseidon.BackOffice.Core.Contracts
{
    public interface INavigationService
    {
        Uri StartPage { get; }
        Uri CurrentPage { get; }

        Uri GoHome();
        bool CanGoHome { get; }

        Uri GoBackOnePage();
        bool CanGoBack { get; }

        Uri GoForwardOnePage();
        bool CanGoForward { get; }

        void ReportNavigation(Uri uri);
    }
}