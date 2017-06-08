using System;
using System.ComponentModel.Composition;
using Devices.Core.Contracts;

namespace Devices.GtkUi
{
    [System.ComponentModel.ToolboxItem(true)]
    [Export(typeof(Devices.Core.Contracts.IBuzzer))]
    public partial class BuzzerWidget : Gtk.Bin, IBuzzer
    {
        public BuzzerWidget()
        {
            this.Build();
        }

        public bool CanFrequency { get {  throw new NotImplementedException();
            }
        }

        public bool CanVolume { get {  throw new NotImplementedException();
            }
        }

        public string Description
        {
            get { throw new NotImplementedException(); }
        }

        public void Beep()
        {
            throw new NotImplementedException();
        }

        public void Sound(int num, int pause)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
