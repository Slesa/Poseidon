using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Poseidon.BackOffice.Core.DesignTime
{
    public class DesignTimeStatusBarViewModel
    {
        public string Message { get { return "This is a message"; } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}