using System;
using System.ComponentModel.Composition;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Devices.Forms
{
    [Export(typeof(FormDevice))]
    public class FormDevice
    {
        public void ExecuteRemote(Action<FormRemoteApp> action)
        {
//            var th = new Thread(() =>
//            {
                var remoteApp = RemoteApp;
                remoteApp.Run();
                action(remoteApp);
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

        public FormRemoteApp _remoteApp;

        public FormRemoteApp RemoteApp
        {
            get
            {
                if (_remoteApp == null)
                {
                    var remoteType = typeof(FormRemoteApp);
                    _remoteApp =
                        AppDomain.CreateInstanceAndUnwrap(remoteType.Assembly.FullName, remoteType.FullName) as FormRemoteApp;
                }
                return _remoteApp;
            }
        }
    }

    public class FormRemoteApp : MarshalByRefObject
    {
        private DeviceWindow _deviceWindow;

        public void Run()
        {
            if (_deviceWindow != null) return;
            _deviceWindow = new DeviceWindow();
            ThreadPool.QueueUserWorkItem(_ => Application.Run(_deviceWindow));
        }

        public FormBuzzerDlg CreateBuzzerDlg()
        {
            var result = new FormBuzzerDlg();
            result.MdiParent = _deviceWindow;
            var children = _deviceWindow.MdiChildren;
            return result;
        }
    }
}