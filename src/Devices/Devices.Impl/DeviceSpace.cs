﻿using System.Collections.Generic;
using System.ComponentModel.Composition;
using Devices.Core.Contracts;

namespace Devices.Core
{
    [Export(typeof(Devices.Core.Contracts.IDeviceSpace))]
    public class DeviceSpace : IDeviceSpace
    {
        public IEnumerable<IDevice> Devices
        {
            get {
                foreach (var buzzer in Buzzers) yield return buzzer;
            }
        }

        [ImportMany(typeof(Devices.Core.Contracts.IBuzzer))]
        IBuzzer[] _buzzers;

        public IEnumerable<IBuzzer> Buzzers
        {
            get { return _buzzers; } 
        }
    }
}