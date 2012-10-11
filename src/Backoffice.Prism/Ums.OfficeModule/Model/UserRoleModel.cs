using System;
using System.ComponentModel;
using System.Linq;
using Microsoft.Practices.Prism.ViewModel;
using Poseidon.Backoffice.Shared.Validators;
using Poseidon.Ums.OfficeModule.Resources;
using Ums.Model;

namespace Poseidon.Ums.OfficeModule.Model
{
    public class UserRoleModel : NotificationObject, IDataErrorInfo
    {
        UserRole _userRole;

        public UserRoleModel()
         {
             _userRole = new UserRole();
         }

        public UserRoleModel(UserRole userRole)
        {
            _userRole = userRole;
        }

        public string Name
        {
            get { return _userRole.Name; }
            set
            {
                _userRole.Name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        #region ErrorInfo

        #endregion

        public string this[string columnName]
        {
            get { return GetValidationError(columnName); }
        }

        public string Error
        {
            get { return ValidatedProperties.Select(GetValidationError).FirstOrDefault(error => error != null); }
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
            }
            return error;
        }

        string ValidateName()
        {
            return OfficeValidators.IsStringMissing(Name) ? Strings.UserRoleModel_Name_missing : null;
        }

        static readonly string[] ValidatedProperties =
            {
                "Name",
            };
    }
}