using System.ComponentModel.Composition;
using System.Windows;
using Caliburn.Micro;

namespace _02_ViewFirst {
    [Export("Shell", typeof(IShell))]
    public class ShellViewModel : PropertyChangedBase, IShell {
        string name;

        public string Name {
            get { return name; }
            set {
                name = value;
                NotifyOfPropertyChange(() => Name);
                NotifyOfPropertyChange(() => CanSayHello);
            }
        }

        public bool CanSayHello {
            get { return !string.IsNullOrWhiteSpace(Name); }
        }

        public void SayHello() {
            MessageBox.Show(string.Format("Hello {0}!", Name));
        }
    }
}