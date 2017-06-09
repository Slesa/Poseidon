using System;
using System.ComponentModel.Composition;
using System.Threading;
using System.Windows.Forms;

namespace Devices.Forms
{
    [Export(typeof(FormDevice))]
    public class FormDevice
    {
        public FormDevice()
        {
            var remoteType = typeof(FormRemoteApp);
            RemoteApp = AppDomain.CreateInstanceAndUnwrap(remoteType.Assembly.FullName, remoteType.FullName) as FormRemoteApp;
            RemoteApp.CreateWindow();
        }

        public void ExecuteRemote(Action<FormRemoteApp> action)
        {
//            var th = new Thread(() =>
//            {
                action(RemoteApp);
                //remoteApp.Run(action);
                //action(remoteApp);
 //           });
 //           th.Start();
        }

        public void Stop()
        {
            if (_appDomain != null)
            {
                AppDomain.Unload(_appDomain);
                _appDomain = null;
            }
        }



        private AppDomain _appDomain;

        public AppDomain AppDomain
        {
            get
            {
                if (_appDomain == null)
                    _appDomain = AppDomain.CreateDomain("Forms Devices");
                return _appDomain;
            }
        }

        public FormRemoteApp RemoteApp { get; set; }
    }

    public class FormRemoteApp : MarshalByRefObject
    {
        private DeviceWindow _deviceWindow;

        public FormBuzzerDlg CreateBuzzerDlg()
        {
            var dlg = new FormBuzzerDlg();
            dlg.MdiParent = _deviceWindow;
            var children = _deviceWindow.MdiChildren;
            return dlg;
        }

        public void CreateWindow()
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                _deviceWindow = new DeviceWindow();
                _deviceWindow.Show();
                CreateBuzzerDlg().Show();
                Application.Run(_deviceWindow);
            });
        }
    }
}