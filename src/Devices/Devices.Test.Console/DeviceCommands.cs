using System;
using System.ComponentModel.Composition;
using Devices.Core.Contracts;

namespace Devices.Test.Console
{
    [Export(typeof(ICommands))]
    public class DeviceCommands : ICommands
    {
        [Import(typeof(IDeviceSpace))]
        private IDeviceSpace deviceSpace { get; set; }

        public enum Verbs
        {
            List, Start, Stop,
        };

        public Execution Handle(string[] input)
        {
            var verb = CommandReader.GetVerb<DeviceCommands.Verbs>(input);
            if (verb == null) return Execution.Empty;

            switch (verb)
            {
                case Verbs.Start:
                    //if (!string.IsNullOrEmpty(target))
                    //{
                    //    var devices = deviceSpace.Devices.Where(dev => dev.Name == target).Select(dev => target);

                    //}
                    StartDevices();
                    return Execution.Done;
                case Verbs.Stop:
                    StopDevices();
                    return Execution.Done;
                case Verbs.List:
                    //if (!CheckTarget(target))
                    //    continue;
                    //switch (target)
                    {
                        //case Target.Devices:
                            System.Console.WriteLine("{0, 20}: Description", "Name");
                            var devices = deviceSpace.Devices;
                            foreach (var device in devices)
                            {
                                System.Console.WriteLine("{0, 20}: {1}", device.Name, device.Description);
                            }
                    }
                    return Execution.Done;
            }
            return Execution.Skip;
        }

        public void PrintVerbs()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Device commands:");
            foreach (var verb in Enum.GetValues(typeof(Verbs)))
            {
                System.Console.WriteLine("- {0}", verb);
            }
        }


        private void StopDevices()
        {
            foreach (var device in deviceSpace.Devices)
                device.Stop();
        }

        private void StartDevices()
        {
            foreach (var device in deviceSpace.Devices)
                device.Start();
        }
    }
}