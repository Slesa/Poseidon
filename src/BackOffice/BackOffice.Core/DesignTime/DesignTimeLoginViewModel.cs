namespace Poseidon.BackOffice.Core.DesignTime
{
    public class DesignTimeLoginViewModel
    {
        public DesignTimeLoginViewModel()
        {
            User = "A user";
            Password = "A password";
        }

        public string User { get; set; }
        public string Password { get; set; }
    }
}