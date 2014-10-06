using System;
using System.Windows.Input;
using Common.Crypto;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Mvvm;
using Poseidon.Common.Persistence.Contracts;
using Poseidon.Ums.Domain.Hibernate.Queries;

namespace Poseidon.BackOffice.Core.ViewModels
{
    public class LoginViewModel : BindableBase, IInteractionRequestAware
    {
        readonly IDbConversation _dbConversation;
        PasswordGenerator _passwordgenerator;

        public LoginViewModel(IDbConversation dbConversation)
        {
            _dbConversation = dbConversation;
            _passwordgenerator = new PasswordGenerator();

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

        string _errorText;
        public string ErrorText
        {
            get { return _errorText; }
            set
            {
                _errorText = value;
                OnPropertyChanged(() => ErrorText);
            }
        }

        #region Commands

        public ICommand LoginCommand { get; private set; }

        void DoLogin()
        {
            _dbConversation.UsingTransaction(() =>
            {
                var user = _dbConversation.Query(new UserByNameQuery(User));
                if (user == null)
                {
                    ErrorText = "User not found or password does not match";
                    return;
                }
                var pw = _passwordgenerator.CreateHash(user.Salt, Password);
                if (pw != user.Password)
                {
                    ErrorText = "User not found or password does not match";
                    return;
                }

            });
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