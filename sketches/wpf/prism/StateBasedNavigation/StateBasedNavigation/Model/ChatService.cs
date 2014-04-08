using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using StateBasedNavigation.Infrastructure;

namespace StateBasedNavigation.Model
{
    public class ChatService : IChatService
    {
        static readonly string Avatar1Uri = @"/StateBasedNavigation;component/Images/MC900432625.PNG";
        static readonly string Avatar2Uri = @"/StateBasedNavigation;component/Images/MC900433938.PNG";
        static readonly string Avatar3Uri = @"/StateBasedNavigation;component/Images/MC900433946.PNG";
        static readonly string Avatar4Uri = @"/StateBasedNavigation;component/Images/MC900434899.PNG";

        private static readonly string[] receivedMessages =
            new[]
            {
                "Hi, how are you?",
                "You will not believe this!",
                "So far so good",
                "Hope you're doing ok...",
                "Yes",
                "No",
                "Sometimes",
                "Is that all?",
                "Can't right now..."
            };

        readonly Dispatcher _dispatcher;
        readonly ITimer _timer;
        readonly ReadOnlyCollection<Contact> _contacts;
        readonly Random _random;
        bool _connected;

        public ChatService()
            : this(new DispatcherTimerWrapper(new TimeSpan(0, 0, 1)))
        {
        }

        ChatService(ITimer timer)
        {
            _dispatcher = Application.Current.Dispatcher;
            _random = new Random();
            _timer = timer;
            _timer.Tick += OnTimerTick;
            _timer.Start();

            _contacts =
                new ReadOnlyCollection<Contact>(
                    new[]
                    {
                        new Contact { Name = "Friend #1", AvatarUri = Avatar1Uri, PersonalMessage = "Enjoying my vacations!" },
                        new Contact { Name = "Friend #2", AvatarUri = Avatar3Uri },
                        new Contact { Name = "Friend #3", AvatarUri = Avatar2Uri },
                        new Contact { Name = "Friend #4", AvatarUri = Avatar1Uri, PersonalMessage = "Work work work work work" },
                        new Contact { Name = "Friend #5", AvatarUri = Avatar4Uri },
                        new Contact { Name = "Friend #6", AvatarUri = Avatar2Uri },
                        new Contact { Name = "Friend #7", AvatarUri = Avatar4Uri },
                        new Contact { Name = "Friend #8", AvatarUri = Avatar2Uri },
                        new Contact { Name = "Friend #9", AvatarUri = Avatar3Uri },
                        new Contact { Name = "Friend #10", AvatarUri = Avatar1Uri }
                    });
        }

        public event EventHandler ConnectionStatusChanged;
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public bool Connected
        {
            get
            {
                return _connected;
            }

            set
            {
                if (_connected == value) return;
                _connected = value;
                var handler = ConnectionStatusChanged;
                if (handler != null) handler(this, EventArgs.Empty);
            }
        }

        public void GetContacts(Action<IOperationResult<IEnumerable<Contact>>> callback)
        {
            _dispatcher.BeginInvoke(new Action(() => callback(new GetContactsOperationResult(this._contacts))));
        }

        public void SendMessage(Contact contact, string message, Action<IOperationResult> callback)
        {
            Timer timer = null;
            timer =
                new Timer(
                    state =>
                    {
                        _dispatcher.BeginInvoke(new Action(() =>
                            {
                                timer.Dispose();
                                Debug.WriteLine("Sent message to '{0}': {1}", contact.Name, message);
                                callback(new OperationResult());
                            }));
                    },
                    null,
                    3000,
                    Timeout.Infinite);
        }

        void OnTimerTick(object sender, EventArgs args)
        {
            if (!Connected) return;

            var coinToss = _random.Next(3);
            if (coinToss == 0)
            {
                ReceiveMessage(
                    GetRandomMessage(_random.Next(receivedMessages.Length)),
                    GetRandomContact(_random.Next(_contacts.Count)));
            }
            else
            {
                coinToss = _random.Next(150);
                if (coinToss == 0)
                {
                    Connected = false;
                }
            }
        }

        void ReceiveMessage(string message, Contact contact)
        {
            var handler = MessageReceived;
            if (handler != null)
            {
                handler(this, new MessageReceivedEventArgs(contact, message));
            }
        }

        string GetRandomMessage(int messageIndex)
        {
            return receivedMessages[messageIndex];
        }

        Contact GetRandomContact(int contactIndex)
        {
            return _contacts[contactIndex];
        }

        private class GetContactsOperationResult : OperationResult<IEnumerable<Contact>>
        {
            public GetContactsOperationResult(IEnumerable<Contact> contacts)
            {
                Result = contacts;
            }
        }

        private class DispatcherTimerWrapper : ITimer
        {
            readonly DispatcherTimer _timer;

            public DispatcherTimerWrapper(TimeSpan interval)
            {
                _timer = new DispatcherTimer { Interval = interval };
            }

            public event EventHandler Tick
            {
                add { _timer.Tick += value; }
                remove { _timer.Tick -= value; }
            }

            public void Start()
            {
                _timer.Start();
            }

            public void Stop()
            {
                _timer.Stop();
            }
        }
    }
}