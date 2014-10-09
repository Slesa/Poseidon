namespace WpfAuthentication.Model
{
    public class AnonymousIdentity : CustomIdentity
    {
        public AnonymousIdentity() 
            : base(string.Empty, string.Empty, new string[]{})
        {
        }
    }
}