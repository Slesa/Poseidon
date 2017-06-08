using System.Windows.Forms;

namespace Devices.Forms
{
    public partial class FormBuzzerDlg : Form
    {
        public FormBuzzerDlg()
        {
            InitializeComponent();
        }

        public bool CanFrequency
        {
            get { return this.checkCanVol.Checked; }
        }

        public bool CanVolume
        {
            get { return this.checkCanVol.Checked; }
        }
    }
}
