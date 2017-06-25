using System;
using System.ComponentModel.Composition;
using System.Runtime.InteropServices;
using Devices.Core.Contracts;

namespace Devices.Forms
{
    [Export(typeof(IBuzzer))]
    public class FormBuzzerDev : IBuzzer
    {
        private FormBuzzerDlg _dialog;

        [Import(typeof(FormDevice))]
        public FormDevice FormDevice { get; set; }

        public bool CanFrequency
        {
            get { return _dialog != null ? _dialog.CanFrequency : false; }
        }

        public bool CanVolume
        {
            get { return _dialog != null ? _dialog.CanVolume : false; }
        }

        public string Description
        {
            get { return "A window as a buzzer for demonstration purpose"; }
        }

        public string Name
        {
            get { return "WinForms Buzzer"; }
        }

        public void Beep()
        {
            _dialog.Beep();
        }

        public void Sound(int num, int pause)
        {
            _dialog.Sound(num, pause);
        }

        public void Start()
        {
            if (_dialog == null)
            {
                _dialog = FormDevice.RemoteApp.FormBuzzerDlg;
            }
            _dialog.ShowRemote();
        }

        public void Stop()
        {
            if (_dialog != null)
            {
                _dialog.HideRemote();
            }
        }
    }
}