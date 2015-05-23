using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using StateBasedNavigation.Infrastructure;
using StateBasedNavigation.Model;

namespace StateBasedNavigation.ViewModels
{
    public class ChatViewModel : ViewModel
    {
        readonly IChatService _chatService;

        public ChatViewModel(IChatService chatService)
        {
            _contacts = new ObservableCollection<Contact>();
            _contactsView = new CollectionView(_contacts);
            _sendMessageRequest = new InteractionRequest<SendMessageViewModel>();
            _showReceivedMessageRequest = new InteractionRequest<ReceivedMessage>();
            _showDetailsCommand = new ShowDetailsCommandImplementation(this);

            _contactsView.CurrentChanged += OnCurrentContactChanged;

            _chatService = chatService;
            _chatService.Connected = true;
            _chatService.ConnectionStatusChanged += (s, e) => RaisePropertyChanged(() => CurrentConnectionState);
            _chatService.MessageReceived += OnMessageReceived;

            _chatService.GetContacts(
                result =>
                    {
                        if (result.Error != null) return;
                        foreach (var item in result.Result)
                        {
                            _contacts.Add(item);
                        }
                    });
            RaisePropertyChanged(() => CurrentConnectionState);
        }

        readonly ObservableCollection<Contact> _contacts;
        public ObservableCollection<Contact> Contacts
        {
            get { return _contacts; }
        }

        readonly CollectionView _contactsView;
        public ICollectionView ContactsView
        {
            get { return _contactsView; }
        }

        readonly InteractionRequest<SendMessageViewModel> _sendMessageRequest;
        public IInteractionRequest SendMessageRequest
        {
            get { return _sendMessageRequest; }
        }

        readonly InteractionRequest<ReceivedMessage> _showReceivedMessageRequest;
        public IInteractionRequest ShowReceivedMessageRequest
        {
            get { return _showReceivedMessageRequest; }
        }

        public enum ConnectionState
        {
            Available, Unavailable
        }

        public IEnumerable<ConnectionState> ConnectionStates
        {
            get
            {
                yield return ConnectionState.Available;
                yield return ConnectionState.Unavailable;
            }
        }

        public ConnectionState CurrentConnectionState
        {
            get { return _chatService.Connected ? ConnectionState.Available : ConnectionState.Unavailable; }
            set { _chatService.Connected = value == ConnectionState.Available; }
        }

        public Contact CurrentContact
        {
            get { return _contactsView.CurrentItem as Contact; }
        }

        bool _showDetails;
        public bool ShowDetails
        {
            get { return _showDetails; }
            set
            {
                if (_showDetails == value) return;
                _showDetails = value;
                RaisePropertyChanged(() => ShowDetails);
            }
        }

        bool _sendingMessage;
        public bool SendingMessage
        {
            get { return _sendingMessage; }
            private set
            {
                if (_sendingMessage == value) return;
                _sendingMessage = value;
                RaisePropertyChanged(() => SendingMessage);
            }
        }

        readonly ShowDetailsCommandImplementation _showDetailsCommand;
        public ICommand ShowDetailsCommand
        {
            get { return _showDetailsCommand; }
        }

        public void SendMessage()
        {
            var contact = CurrentContact;
            _sendMessageRequest.Raise(
                new SendMessageViewModel(contact, this),
                sendMessage =>
                    {
                        if (!sendMessage.Result.HasValue || !sendMessage.Result.Value) return;
                        SendingMessage = true;

                        _chatService.SendMessage(
                            contact,
                            sendMessage.Message,
                            result =>
                                {
                                    SendingMessage = false;
                                });
                    });
        }

        void OnCurrentContactChanged(object sender, EventArgs a)
        {
            RaisePropertyChanged(() => CurrentContact);
            _showDetailsCommand.RaiseCanExecuteChanged();
        }

        void OnMessageReceived(object sender, MessageReceivedEventArgs a)
        {
            _showReceivedMessageRequest.Raise(a.Message);
        }

        class ShowDetailsCommandImplementation : ICommand
        {
            readonly ChatViewModel _owner;

            public ShowDetailsCommandImplementation(ChatViewModel owner)
            {
                _owner = owner;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return _owner.ContactsView.CurrentItem != null;
            }

            public void Execute(object parameter)
            {
                _owner.ShowDetails = (bool) parameter;
            }

            public void RaiseCanExecuteChanged()
            {
                var handler = CanExecuteChanged;
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }
        }
    }
}