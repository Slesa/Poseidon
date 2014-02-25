using System.ComponentModel.Composition;
using Caliburn.Micro;
using _11_Screens.Framework;

namespace _11_Screens.Shell 
{
    [Export(typeof(IMessageBox)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class MessageBoxViewModel : Screen, IMessageBox 
    {
        MessageBoxOptions _selection;

        public bool OkVisible 
        {
            get { return IsVisible(MessageBoxOptions.Ok); }
        }

        public bool CancelVisible 
        {
            get { return IsVisible(MessageBoxOptions.Cancel); }
        }

        public bool YesVisible 
        {
            get { return IsVisible(MessageBoxOptions.Yes); }
        }

        public bool NoVisible 
        {
            get { return IsVisible(MessageBoxOptions.No); }
        }

        public string Message { get; set; }
        public MessageBoxOptions Options { get; set; }

        public void Ok() 
        {
            Select(MessageBoxOptions.Ok);
        }

        public void Cancel() 
        {
            Select(MessageBoxOptions.Cancel);
        }

        public void Yes() 
        {
            Select(MessageBoxOptions.Yes);
        }

        public void No() 
        {
            Select(MessageBoxOptions.No);
        }

        public bool WasSelected(MessageBoxOptions option) 
        {
            return (_selection & option) == option;
        }

        bool IsVisible(MessageBoxOptions option) 
        {
            return (Options & option) == option;
        }

        void Select(MessageBoxOptions option) 
        {
            _selection = option;
            TryClose();
        }
    }
}