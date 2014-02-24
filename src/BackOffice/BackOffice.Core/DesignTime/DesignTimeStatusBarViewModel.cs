using System.ComponentModel;
using System.Runtime.CompilerServices;
using BackOffice.Core.Contracts;

namespace BackOffice.Core.DesignTime
{
    public class DesignTimeStatusBarViewModel : IStatusBarViewModel
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