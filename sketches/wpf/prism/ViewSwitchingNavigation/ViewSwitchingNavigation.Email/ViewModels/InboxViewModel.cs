using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using ViewSwitchingNavigation.Email.Model;
using ViewSwitchingNavigation.Infrastructure;

namespace ViewSwitchingNavigation.Email.ViewModels
{
    public class InboxViewModel : NotificationObject
    {
        private const string ComposeEmailViewKey = "ComposeEmailView";
        private const string ReplyToKey = "ReplyTo";
        private const string EmailViewKey = "EmailView";
        private const string EmailIdKey = "EmailId";

        private readonly SynchronizationContext synchronizationContext;
        private readonly IEmailService _emailService;
        private readonly IRegionManager _regionManager;
        private readonly ObservableCollection<EmailDocument> messagesCollection;

        private static Uri ComposeEmailViewUri = new Uri(ComposeEmailViewKey, UriKind.Relative);

        public InboxViewModel(IEmailService emailService, IRegionManager regionManager)
        {
            synchronizationContext = SynchronizationContext.Current ?? new SynchronizationContext();

            _composeMessageCommand = new DelegateCommand<object>(ComposeMessage);
            _replyMessageCommand = new DelegateCommand<object>(ReplyMessage, CanReplyMessage);
            _openMessageCommand = new DelegateCommand<EmailDocument>(OpenMessage);

            messagesCollection = new ObservableCollection<EmailDocument>();
            Messages = new CollectionView(this.messagesCollection);
            Messages.CurrentChanged += (s, e) =>
                _replyMessageCommand.RaiseCanExecuteChanged();

            _emailService = emailService;
            _regionManager = regionManager;

            if (_emailService != null)
            {
                _emailService.BeginGetEmailDocuments(
                    r =>
                        {
                            var messages = _emailService.EndGetEmailDocuments(r);
                            synchronizationContext.Post(
                                s =>
                                    {
                                        foreach (var message in messages)
                                        {
                                            messagesCollection.Add(message);
                                        }
                                    }, null);
                        }, null);
            }
        }

        internal InboxViewModel()
        {
        }

        public ICollectionView Messages { get; internal set; }

    #region Commands

        readonly DelegateCommand<object> _composeMessageCommand;
        public ICommand ComposeMessageCommand
        {
            get { return _composeMessageCommand; }
        }

        void ComposeMessage(object ignored)
        {
            // todo: 02 - New Email: Navigating to a view in a region
            // Any region can be navigated by passing in a relative Uri for the email view name.
            // By the default, the navigation service will look for an item already in the region
            // with a type name that matches the Uri.
            //
            // If an item is not found in the region, the navigation services uses the 
            // ServiceLocator to find an item that matches the Uri, in the example below it would
            // be ComposeEmailView.
            _regionManager.RequestNavigate(RegionNames.MainContentRegion, ComposeEmailViewUri);
        }


        readonly DelegateCommand<object> _replyMessageCommand;
        public ICommand ReplyMessageCommand
        {
            get { return _replyMessageCommand; }
        }
        bool CanReplyMessage(object ignored)
        {
            return Messages.CurrentItem != null;
        }

        void ReplyMessage(object ignored)
        {
            // todo: 03 - Reply Email: Navigating to a view in a region with context
            // When navigating, you can also supply context so the target view or
            // viewmodel can orient their data to something appropriate.  In this case,
            // we've chosen to pass the email id in a name/value pair as part of the Uri.
            //
            // The recipient of the context can get access to this information by
            // implementing the INavigationAware or IConfirmNavigationRequest interface, as shown by the 
            // the ComposeEmailViewModel.
            //
            var currentEmail = Messages.CurrentItem as EmailDocument;
            var builder = new StringBuilder();
            builder.Append(ComposeEmailViewKey);
            if (currentEmail != null)
            {
                var query = new UriQuery {{ReplyToKey, currentEmail.Id.ToString("N")}};
                builder.Append(query);
            }
            _regionManager.RequestNavigate(RegionNames.MainContentRegion, new Uri(builder.ToString(), UriKind.Relative));
        }


        readonly DelegateCommand<EmailDocument> _openMessageCommand;
        public ICommand OpenMessageCommand
        {
            get { return _openMessageCommand; }
        }

        void OpenMessage(EmailDocument document)
        {
            // todo: 04 - Open Email: Navigating to a view in a region with context
            // When navigating, you can also supply context so the target view or
            // viewmodel can orient their data to something appropriate.  In this case,
            // we've chosen to pass the email id in a name/value pair as part of the Uri.
            //
            // The EmailViewModel retrieves this context by implementing the INavigationAware
            // interface.
            //
            var builder = new StringBuilder();
            builder.Append(EmailViewKey);
            var query = new UriQuery {{EmailIdKey, document.Id.ToString("N")}};
            builder.Append(query);
            _regionManager.RequestNavigate(RegionNames.MainContentRegion, new Uri(builder.ToString(), UriKind.Relative));
        }

    #endregion
    }
}