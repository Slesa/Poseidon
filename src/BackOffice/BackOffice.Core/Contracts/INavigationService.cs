using System;

namespace BackOffice.Core.Contracts
{
    public interface INavigationService
    {
        Uri GoBackOnePage();
        bool CanGoBack { get; }
        Uri GoForwardOnePage();
        bool CanGoForward { get; }
        void ReportNavigation(Uri uri);
    }
}