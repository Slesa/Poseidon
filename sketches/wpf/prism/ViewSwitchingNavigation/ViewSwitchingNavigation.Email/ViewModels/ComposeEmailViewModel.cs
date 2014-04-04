using System;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using ViewSwitchingNavigation.Email.Model;

namespace ViewSwitchingNavigation.Email.ViewModels
{
    public class ComposeEmailViewModel : NotificationObject, IConfirmNavigationRequest
    {
        private const string NormalStateKey = "Normal";
        private const string SendingStateKey = "Sending";
        private const string SentStateKey = "Sent";
        
        private const string ReplyToParameterKey = "ReplyTo";
        private const string ToParameterKey = "To";

        private readonly SynchronizationContext _synchronizationContext;
        private readonly IEmailService _emailService;
        private EmailDocument _emailDocument;
        private string _sendState;
        private IRegionNavigationJournal _navigationJournal;

        public ComposeEmailViewModel(IEmailService emailService)
        {
            _synchronizationContext = SynchronizationContext.Current ?? new SynchronizationContext();
            _sendEmailCommand = new DelegateCommand(SendEmail);
            _cancelEmailCommand = new DelegateCommand(CancelEmail);
            _confirmExitInteractionRequest = new InteractionRequest<Confirmation>();
            _sendState = NormalStateKey;

            _emailService = emailService;
        }

    #region Commands

        private readonly DelegateCommand _sendEmailCommand;
        public ICommand SendEmailCommand
        {
            get { return _sendEmailCommand; }
        }

        private readonly DelegateCommand _cancelEmailCommand;
        public ICommand CancelEmailCommand
        {
            get { return _cancelEmailCommand; }
        }

        private readonly InteractionRequest<Confirmation> _confirmExitInteractionRequest;
        public IInteractionRequest ConfirmExitInteractionRequest
        {
            get { return _confirmExitInteractionRequest; }
        }

    #endregion

        public EmailDocument EmailDocument
        {
            get
            {
                return _emailDocument;
            }

            set
            {
                if (_emailDocument == value) return;
                _emailDocument = value;
                RaisePropertyChanged(() => EmailDocument);
            }
        }

        public string SendState
        {
            get { return _sendState; }

            private set
            {
                if (_sendState == value) return;
                _sendState = value;
                RaisePropertyChanged(() => SendState);
            }
        }

        private void SendEmail()
        {
            SendState = SendingStateKey;
            _emailService.BeginSendEmailDocument(
                _emailDocument,
                r => _synchronizationContext.Post(
                    s =>
                        {
                            SendState = SentStateKey;

                            // todo: 05 - Send Email: Navigating back
                            // After the email has been 'sent' (we're using a mock mail service 
                            // in this application), the view model uses the navigation journal 
                            // it captured when it was navigated to (see the OnNavigatedTo in 
                            // this class) to navigate the region to the prior view.  
                            if (_navigationJournal != null)
                            {
                                _navigationJournal.GoBack();
                            }
                        },
                    null),
                null);

        }

        private void CancelEmail()
        {
            // todo: 06 - Cancel Email : Navigating backwards
            // When the user elects to cancel the email, we navigate the region backwards.
            //
            // Because the view model implements the IConfirmNavigationRequest
            // it has the option to interrupt the navigation for the region if there
            // changes to the email.  See the ConfirmNavigationRequest implementation below
            // for more details on this.
            // 
            if (_navigationJournal != null)
            {
                _navigationJournal.GoBack();
            }
        }

        void IConfirmNavigationRequest.ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            // todo: 07 - Confirming Navigation Requests
            // There are times when a view (or view model) wish to be able to cancel a navigation request.
            // For this email, the user may have started but not sent an email.  We want to confirm with
            // the user that they want to discard their changes before completing the navigation.
            //
            // The view model uses the InteractionRequest to prompt the user (this is explained in more
            // detail in Prism's MVVM guidance) and, if the user confirms they want to navigate away,
            // then continues the navigation by using the continuationCallback passed in as a parameter.
            //
            // NOTE: You MUST invoke the continuationCallback action or you will halt this current
            // navigation request and no further processing of this request willl take place.  
            if (_sendState == NormalStateKey)
            {
                _confirmExitInteractionRequest.Raise(
                    new Confirmation { Content = "Are you sure you want to navigate away from this email?", Title = "Confirm" },
                    c => { continuationCallback(c.Confirmed); });
            }
            else
            {
                continuationCallback(true);
            }
        }

        bool INavigationAware.IsNavigationTarget(NavigationContext navigationContext)
        {
            // We always want a new instance of a composed email, so we should return false to indicate
            // this doesn't handle the navigation request.
            return false;
        }

        void INavigationAware.OnNavigatedFrom(NavigationContext navigationContext)
        {
            // Intentionally not implemented
        }

        void INavigationAware.OnNavigatedTo(NavigationContext navigationContext)
        {
            // todo: 09 - Email OnNavigatedTo : Accessing navigation context.
            // When this view model is navigated to it gains access to the
            // NavigationContext to determine if we are composing a new email
            // or replying to an existing one.
            //
            // The navigation context offers the context information through
            // the Parameters property that is a string/value dictionairy
            // built from the navigation Uri.
            //
            // In this example, we look for the 'ReplyTo' value to 
            // determine if we are replying to an email and, if so, 
            // retrieving it's relevant information from the email service
            // to pre-populate response values.
            //
            var emailDocument = new EmailDocument();

            var parameters = navigationContext.Parameters;

            var replyTo = parameters[ReplyToParameterKey];
            Guid replyToId;
            if (replyTo != null && Guid.TryParse(replyTo, out replyToId))
            {
                var replyToEmail = _emailService.GetEmailDocument(replyToId);
                if (replyToEmail != null)
                {
                    emailDocument.To = replyToEmail.From;
                    emailDocument.Subject = "RE: " + replyToEmail.Subject;

                    emailDocument.Text =
                        Environment.NewLine +
                        replyToEmail.Text
                            .Split(Environment.NewLine.ToCharArray())
                            .Select(l => l.Length > 0 ? ">> " + l : l)
                            .Aggregate((l1, l2) => l1 + Environment.NewLine + l2);
                }
            }
            else
            {
                var to = parameters[ToParameterKey];
                if (to != null)
                {
                    emailDocument.To = to;
                }
            }

            EmailDocument = emailDocument;

            // todo: 10 - Email OnNaviatedTo : Capture the navigation service journal
            // You can capture the navigation service or navigation service journal
            // to navigate the region you're placed in without having to expressly 
            // know which region to navigate.
            //
            // This is useful if you need to navigate 'back' at some point after this
            // view model closes.
            _navigationJournal = navigationContext.NavigationService.Journal;
        }
    }
}