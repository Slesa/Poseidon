using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading;
using System.Windows.Controls;
using WpfAuthentication.Contracts;
using WpfAuthentication.Helpers;
using WpfAuthentication.Model;
using WpfAuthentication.Views;

namespace WpfAuthentication.ViewModels
{
    public class AuthenticationViewModel : IViewModel, INotifyPropertyChanged
    {
        readonly IAuthenticationService _authenticationService;

        public event PropertyChangedEventHandler PropertyChanged;


        public AuthenticationViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            LoginCommand = new DelegateCommand(Login, CanLogin);
            LogoutCommand = new DelegateCommand(Logout, CanLogout);
            ShowViewCommand = new DelegateCommand(ShowView);
        }

        string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string AuthenticatedUser 
        {
            get
            {
                if(IsAuthenticated)
                    return string.Format("Signed in as {0}. {1}",
                        Thread.CurrentPrincipal.Identity.Name,
                        Thread.CurrentPrincipal.IsInRole("Administrators") 
                            ? "You are an administrator!" 
                            : "You are NOT a member of the administrators group.");
                return "Not authenticated";
            }
        }

        string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        public bool IsAuthenticated
        {
            get { return Thread.CurrentPrincipal.Identity.IsAuthenticated; }
        }

        #region Commands

        public DelegateCommand LoginCommand { get; private set; }

        void Login(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var clearPassword = passwordBox.Password;
            try
            {
                var user = _authenticationService.AuthenticateUser(Username, clearPassword);
                var customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
                if (customPrincipal == null)
                {
                    throw new ArgumentException(
                        "The application's default principal must be set to a CustomPrincipal object on startup.");
                }

                customPrincipal.Identity = new CustomIdentity(user.Username, user.Email, user.Roles);

                RaiseChanges();

                Username = string.Empty;
                passwordBox.Password = string.Empty;
                Status = string.Empty;
            }
            catch (UnauthorizedAccessException)
            {
                Status = "Login failed! Please provide some valid credentials.";
            }
            catch (Exception ex)
            {
                Status = string.Format("ERROR: {0}", ex.Message);
            }
        }
            

        bool CanLogin(object obj)
        {
            return !IsAuthenticated;
        }


        public DelegateCommand LogoutCommand { get; private set; }

        void Logout(object obj)
        {
            var customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
            if (customPrincipal == null) return;

            customPrincipal.Identity = new AnonymousIdentity();
            RaiseChanges();
            Status = string.Empty;
        }

        bool CanLogout(object obj)
        {
            return IsAuthenticated;
        }

        public DelegateCommand ShowViewCommand { get; private set; }

        void ShowView(object parameter)
        {
            try
            {
                Status = string.Empty;
                IView view;
                if(parameter== null)
                    view = new SecretWindow();
                else
                    view = new AdminWindow();
                view.Show();
            }
            catch (SecurityException)
            {
                Status = "You are not authorized!";
            }
        }

        void RaiseChanges()
        {
                OnPropertyChanged("AuthenticatedUser");
                OnPropertyChanged("IsAuthenticated");
                LoginCommand.RaiseCanExecuteChanged();
                LogoutCommand.RaiseCanExecuteChanged();
        }
        #endregion


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) 
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}