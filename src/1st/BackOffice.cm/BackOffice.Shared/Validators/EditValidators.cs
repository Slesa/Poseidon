using System.Text.RegularExpressions;

namespace BackOffice.Shared.Validators
{
    public static class EditValidators
    {
        public static bool IsStringMissing(string value)
        {
            return string.IsNullOrEmpty(value) || value.Trim() == string.Empty;
        }

        public static bool IsValidEmailAddress(string email)
        {
            if (IsStringMissing(email))
                return false;

            // This regex pattern came from: http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx
            var pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }
    }
}