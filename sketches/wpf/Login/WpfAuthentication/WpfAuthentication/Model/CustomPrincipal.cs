using System.Linq;
using System.Security.Principal;

namespace WpfAuthentication.Model
{
    public class CustomPrincipal : IPrincipal
    {
        CustomIdentity _identity;

        public CustomIdentity CustomIdentity
        {
            get { return _identity ?? new AnonymousIdentity(); }
            set { _identity = value; }
        }

        public bool IsInRole(string role)
        {
            return _identity.Roles.Contains(role);
        }

        public IIdentity Identity
        {
            get { return CustomIdentity; }
            set { CustomIdentity = value as CustomIdentity; }
        }
    }
}