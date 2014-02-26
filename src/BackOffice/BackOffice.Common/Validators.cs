using System.Text.RegularExpressions;

namespace Poseidon.BackOffice.Common
{
    /// <summary>
    /// A collection of common validators
    /// </summary>
    public static class Validators
    {
        /// <summary>
        /// Checks if the string is empty or consists only of spaces or tabs.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true if the string is considered to be empty</returns>
        public static bool IsStringMissing(string value)
        {
            return string.IsNullOrEmpty(value) || value.Trim() == string.Empty;
        }

        /// <summary>
        /// Checks if the string is a valid mail address.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true if email is a valid mail address</returns>
        public static bool IsValidEmailAddress(string email)
        {
            if (IsStringMissing(email))
                return false;

            // This regex pattern came from: http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx
            const string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }
    }
}