using System;
using System.ComponentModel;
using System.Linq;
using BackOffice.Shared.Validators;
using Caliburn.Micro;
using Ums.Model;
using Ums.OfficeModule.Resources;

namespace Ums.OfficeModule.Model
{
    public class UserRoleModel : PropertyChangedBase, IDataErrorInfo
    {
        readonly UserRole _userRole;

        public UserRoleModel()
        {
            _userRole = new UserRole();
        }

        public UserRoleModel(UserRole userRole)
        {
            _userRole = userRole;
        }

        public UserRole UserRole { get { return _userRole; } }

        public string Name
        {
            get { return _userRole.Name; }
            set { _userRole.Name = value; NotifyOfPropertyChange(()=>Error); }
        }

        public string this [string columnName]
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
            };

        string GetValidationError(string columnName)
        {
            if (Array.IndexOf(ValidatedProperties, columnName)<0)
                return null;
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
            return EditValidators.IsStringMissing(Name) ? Strings.UserRoleModel_Name_missing : null;
        }
    }
}