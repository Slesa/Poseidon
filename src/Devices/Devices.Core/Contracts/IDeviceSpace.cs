using System;
using System.Collections.Generic;

namespace Devices.Core.Contracts
{
    public interface IDeviceSpace
    {
        IEnumerable<IDevice> Devices { get; }
        IEnumerable<IBuzzer> Buzzers { get; }
    }
}
