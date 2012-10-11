using System;
using System.ComponentModel;
using System.Linq;
using Microsoft.Practices.Prism.ViewModel;
using Poseidon.Backoffice.Shared.Validators;
using Poseidon.Ums.OfficeModule.Resources;
using Ums.Model;

namespace Poseidon.Ums.OfficeModule.Model
{
    public class UserModel : NotificationObject, IDataErrorInfo
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

        public string Name
        {
            get { return _user.Name; }
            set
            {
                _user.Name = value;
                RaisePropertyChanged(()=>Name);
            }
        }

        public UserRole UserRole
        {
            get { return _user.UserRole; }
            set
            {
                _user.UserRole = value;
                RaisePropertyChanged(() => UserRole);
            }
        }
        #region ErrorInfo

        public string this[string columnName]
        {
            get { return GetValidationError(columnName); }
        }

        public string Error
        {
            get { return ValidatedProperties.Select(GetValidationError).FirstOrDefault(Error => Error != null); }
        }

        string GetValidationError(string columnName)
        {
            if (Array.IndexOf(ValidatedProperties, columnName) < 0) return null;

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

        static readonly string[] ValidatedProperties =
            {
                "Name",
                "UserRole",
            };

        string ValidateName()
        {
            return OfficeValidators.IsStringMissing(Name) ? Strings.UserModel_Name_missing : null;
        }

        string ValidateUserRole()
        {
            return UserRole == null ? Strings.UserModel_UserRole_missing : null;
        }

        #endregion

    }
}