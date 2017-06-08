using System;
using System.ComponentModel.Composition;
using Devices.Core.Contracts;

namespace Devices.Forms
{
    [Export(typeof(Devices.Core.Contracts.IBuzzer))]
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
            throw new NotImplementedException();
        }

        public void Sound(int num, int pause)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            if (_dialog == null)
            {
                FormDevice.ExecuteRemote(remote =>
                {
                    _dialog = remote.CreateBuzzerDlg();
                    _dialog.Show();
                });
                /*    (FormBuzzerDlg)
                    FormDevice.AppDomain.CreateInstanceAndUnwrap(
                        typeof(FormBuzzerDlg).Assembly.FullName,
                        typeof(FormBuzzerDlg).FullName);*/
            }
            //System.Windows.Forms.Application.Run(_dialog);
        }

        public void Stop()
        {
            _dialog.Hide();
            _dialog = null;
        }
    }
}