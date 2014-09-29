using System.Security.Cryptography;

namespace Common.Crypto
{
    public class PasswordGenerator
    {
        private readonly RNGCryptoServiceProvider _provider = new RNGCryptoServiceProvider();

        public string Salt
        {
            get
            {
                var salt = new byte[32];
                _provider.GetBytes(salt);
                return System.Convert.ToBase64String(salt, 0, 32);
            }
        }

        public string CreateHash(string salt, string password)
        {
            var binary = System.Text.Encoding.UTF32.GetBytes(salt + password);

            var sha = SHA256.Create();
            var hash = sha.ComputeHash(binary);
            return System.Convert.ToBase64String(hash, 0, 32);
        }
    }
}