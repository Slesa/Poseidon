using System;
using System.ComponentModel;
using System.Linq;
using BackOffice.Shared.Validators;
using Caliburn.Micro;
using Ums.Model;
using Ums.OfficeModule.Resources;

namespace Ums.OfficeModule.Model
{
    public class UserChangedEvent
    {
        public UserChangedEvent(User user)
        {
            User = user;
        }
        public User User { get; set; }
    }

    public class UserRemovedEvent
    {
        public UserRemovedEvent(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }

    public class UserModel : PropertyChangedBase, IDataErrorInfo
    {
        readonly User _user;

        public UserModel()
        {
            _user = new User();
        }

        public UserModel(User user)
        {
            _user = user;
        }

        public User User
        {
            get { return _user; }
        }

        public string Name
        {
            get { return _user.Name; }
            set
            {
                _user.Name = value;
                NotifyOfPropertyChange(() => Error);
            }
        }

        public UserRole UserRole
        {
            get { return _user.UserRole; }
            set
            {
                _user.UserRole = value;
                NotifyOfPropertyChange(() => Error);
            }
        }

        public string this[string columnName]
        {
            get { return GetValidationError(columnName); }
        }

        public string Error
        {
            get { return ValidatedProperties.Select(GetValidationError).FirstOrDefault(error => error != null); }
        }

        static readonly string[] ValidatedProperties =
            {
                "Name",
                "UserRole",
            };

        string GetValidationError(string columnName)
        {
            if (Array.IndexOf(ValidatedProperties, columnName) < 0)
                return null;
            string error = null;
            switch(columnName)
            {
                case "Name":
                    error = ValidateName();
                    break;
                case "UserRole":
                    error = ValidateUserRole();
                    break;
            }
            return error;
        }

        string ValidateName()
        {
            return EditValidators.IsStringMissing(Name) ? Strings.UserModel_Name_missing : null;
        }
        string ValidateUserRole()
        {
            return UserRole == null ? (string) Strings.UserModel_UserRole_missing : null;
        }
    }
}