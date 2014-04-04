using System;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using ViewSwitchingNavigation.Email.Model;

namespace ViewSwitchingNavigation.Email.ViewModels
{
    public class EmailViewModel : NotificationObject, INavigationAware
    {
        readonly DelegateCommand _goBackCommand;
        readonly IEmailService _emailService;
        EmailDocument _email;
        IRegionNavigationJournal _navigationJournal;
        const string EmailIdKey = "EmailId";

        public EmailViewModel(IEmailService emailService)
        {
            _goBackCommand = new DelegateCommand(GoBack);

            _emailService = emailService;
        }

        public ICommand GoBackCommand
        {
            get { return _goBackCommand; }
        }

        public EmailDocument Email
        {
            get { return _email; }

            set
            {
                if (_email != value)
                {
                    _email = value;
                    RaisePropertyChanged(() => Email);
                }
            }
        }


        void GoBack()
        {
            // todo: 15 - Using the journal to navigate back.
            //
            // This view model offers a GoBack command and uses
            // the journal captured in OnNavigatedTo to
            // navigate back to the prior view.
            if (_navigationJournal != null)
            {
                _navigationJournal.GoBack();
            }
        }

        Guid? GetRequestedEmailId(NavigationContext navigationContext)
        {
            var email = navigationContext.Parameters[EmailIdKey];
            Guid emailId;
            if (email != null && Guid.TryParse(email, out emailId))
            {
                return emailId;
            }

            return null;
        }

        #region INavigationAware

        bool INavigationAware.IsNavigationTarget(NavigationContext navigationContext)
        {
            // todo: 13 - Determining if a view or view model handles the navigation request
            //
            // By implementing IsNavigationTarget, this view model can let the region
            // navigation service know that it is the item sought for navigation. 
            // 
            // If this view model is the one that was built to display the requested
            // EmailId (as a result of a prior navigation request), then this
            // method will return true.  
            //
            // Otherwise, it will return false and if no other EmailViewModel type returns true 
            // then the navigation service knows that no EmailView is already available that 
            // shows that email.  In this case, the navigation service will request a new one 
            // be constructed and added to the region.
            if (_email == null)
            {
                return true;
            }

            var requestedEmailId = GetRequestedEmailId(navigationContext);

            return requestedEmailId.HasValue && requestedEmailId.Value == _email.Id;
        }

        void INavigationAware.OnNavigatedFrom(NavigationContext navigationContext)
        {
            // Intentionally not implemented.
        }

        void INavigationAware.OnNavigatedTo(NavigationContext navigationContext)
        {
            // todo: 15 - Orient to the right context
            //
            // When this view model is navigated to, it gathers the
            // requested EmailId from the navigation context's parameters.
            //
            // It also captures the navigation Journal so it
            // can offer a 'go back' command.
            var emailId = GetRequestedEmailId(navigationContext);
            if (emailId.HasValue)
            {
                Email = _emailService.GetEmailDocument(emailId.Value);
            }

            _navigationJournal = navigationContext.NavigationService.Journal;
        }

        #endregion
    }
}

