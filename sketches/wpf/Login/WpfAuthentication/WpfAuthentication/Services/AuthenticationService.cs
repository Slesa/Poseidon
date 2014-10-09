using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WpfAuthentication.Contracts;
using WpfAuthentication.Model;

namespace WpfAuthentication.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        class InternalUserData
        {
            public InternalUserData(string username, string email, string hashedPassword, string[] roles)
            {
                Username = username;
                Email = email;
                HashedPassword = hashedPassword;
                Roles = roles;
            }

            public string Username { get; set; }
            public string Email { get; set; }
            public string HashedPassword { get; set; }
            public string[] Roles { get; set; }
        }

        static readonly List<InternalUserData> _users = new List<InternalUserData>()
        {
            new InternalUserData("Mark", "mark@company.com", "MB5PYIsbI2YzCUe34Q5ZU2VferIoI4Ttd+ydolWV0OE=",
                new string[] {"Administrator"}),
            new InternalUserData("John", "john@company.com", "hMaLizwzOQ5LeOnMuj+C6W75Zl5CXXYbwDSHWW9ZOXc=",
                new string[] {})
        };

        public User AuthenticateUser(string username, string password)
        {
            var userData =
                _users.FirstOrDefault(u => u.Username.Equals(username)
                                           && u.HashedPassword.Equals(CalculateHash(password, u.Username)));
            if (userData == null)
                throw new UnauthorizedAccessException("Access denied. Please provide some valid credentials.");

            return new User(userData.Username, userData.Email, userData.Roles);
        }

        string CalculateHash(string clearTextPassword, string salt)
        {
            // Convert the salted password to a byte array
            var saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);
            // Use the hash algorithm to calculate the hash
            var algorithm = new SHA256Managed();
            var hash = algorithm.ComputeHash(saltedHashBytes);
            // Return the hash as a base64 encoded string to be compared to the stored password
            return Convert.ToBase64String(hash);
        }
    }
}