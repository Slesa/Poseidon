using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.ServiceLocation;
using Poseidon.BackOffice.Common;


namespace Poseidon.BackOffice.ViewModels
{
    public class ShellViewModel
    {
        public ShellViewModel()
        {

            LoginUserRequest = new InteractionRequest<INotification>();

            OnQuitCommand = new DelegateCommand(OnQuit);
            LoginUserCommand = new DelegateCommand(RaiseLoginUserRequest, CanRaiseLoginUserRequest);

            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
                eventAggregator.GetEvent<ApplicationReadyEvent>().Subscribe(_ => RaiseLoginUserRequest());
            }
        }

        #region Commands

        public ICommand OnQuitCommand { get; private set; }

        void OnQuit()
        {
            Application.Current.Shutdown();
        }

        public ICommand LoginUserCommand { get; private set; }

        void RaiseLoginUserRequest()
        {
            LoginUserRequest.Raise(new Notification
            {
                Title = "Enter credentials..."
            }, LoginNotification);
        }

        void LoginNotification(INotification obj)
        {
            
            var i = obj;
        }

        bool CanRaiseLoginUserRequest()
        {
            return true;
        }


        #endregion

        #region Interaction

        public InteractionRequest<INotification> LoginUserRequest { get; private set; }

        #endregion

    }
}