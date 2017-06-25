using System.Collections.Generic;
using System.ComponentModel.Composition;
using Devices.Core.Contracts;

namespace Devices.Impl
{
    [Export(typeof(IDeviceSpace))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class DeviceSpace : IDeviceSpace
    {
        public IEnumerable<IDevice> Devices
        {
            get {
                foreach (var buzzer in Buzzers) yield return buzzer;
            }
        }

        [ImportMany(typeof(IBuzzer))]
        private IBuzzer[] _buzzers;

        public IEnumerable<IBuzzer> Buzzers
        {
            get { return _buzzers; } 
        }
    }
}