using System;

namespace Poseidon.BackOffice.Core.DesignTime
{
    public class DesignTimeLoginViewModel
    {
        public DesignTimeLoginViewModel()
        {
            User = "A user";
            Password = "A password";
            Image = new Uri("pack://application:,,,/Poseidon.BackOffice.Core;component/DesignTime/Resources/User.png");

        }

        public string User { get; set; }
        public string Password { get; set; }
        public Uri Image { get; set; }
    }
}