using System;

namespace Devices
{
    public interface IDrawer : IDevice
    {
        long Timeout { get; }
        bool CanReportStatus { get; }

        void Open();
        bool IsOpen { get; }
        bool WaitForClose();

        event EventHandler Opened;
        event EventHandler Closed;
    }
}
