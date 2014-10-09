using WpfAuthentication.Model;

namespace WpfAuthentication.Contracts
{
    public interface IAuthenticationService
    {
        User AuthenticateUser(string username, string password);
    }
}