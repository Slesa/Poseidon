using System;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Mvvm;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class LoginViewModel : BindableBase, IInteractionRequestAware
    {
        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand(DoLogin, CanLogin);
            CancelCommand = new DelegateCommand(DoCancel);
        }

        string _user;
        public string User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(()=>User);
                ((DelegateCommand) LoginCommand).RaiseCanExecuteChanged();
            }
        }

        string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(() => Password);
            }
        }

        #region Commands

        public ICommand LoginCommand { get; private set; }

        void DoLogin()
        {
            CallFinishInteraction();
        }

        bool CanLogin()
        {
            return !string.IsNullOrEmpty(User);
        }

        public ICommand CancelCommand { get; private set; }

        void DoCancel()
        {
            CallFinishInteraction();
        }

    #endregion

        void CallFinishInteraction()
        {
            if (FinishInteraction != null) FinishInteraction();
        }

        public INotification Notification { get; set; }
        public Action FinishInteraction { get; set; }
    }
}