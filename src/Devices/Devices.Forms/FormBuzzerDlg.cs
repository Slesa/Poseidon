using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Devices.Forms.Properties;

namespace Devices.Forms
{
    public partial class FormBuzzerDlg : Form
    {
        public FormBuzzerDlg()
        {
            InitializeComponent();
            pictureState.Image = Resources.BuzzerOff;
        }

        public void ShowRemote()
        {
            Invoke(new Action(Show));
        }

        public void HideRemote()
        {
            Invoke(new Action(Hide));
        }

        public bool CanFrequency
        {
            get { return this.checkCanVol.Checked; }
        }

        public bool CanVolume
        {
            get { return this.checkCanVol.Checked; }
        }

        public void Beep()
        {
            Task.Factory
                .StartNew( async () =>
                {
                    pictureState.Image = Resources.BuzzerOn;
                    await Task.Delay(300);
                    pictureState.Image = Resources.BuzzerOff;
                });
        }

        public void Sound(int num, int pause)
        {
            Task.Factory
                .StartNew(async () =>
                {
                    for (var i = 0; i < num; i++)
                    {
                        pictureState.Image = Resources.BuzzerOn;
                        await Task.Delay(pause);
                        pictureState.Image = Resources.BuzzerOff;
                    }
                });
        }
    }
}
