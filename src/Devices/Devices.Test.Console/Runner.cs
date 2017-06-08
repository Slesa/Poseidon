using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using Devices.Core.Contracts;

namespace Devices.Test.Console
{
    enum Verb
    {
        Quit, Exit, List, Start, Stop,
        Unknown,
    }

    enum Target
    {
        Devices, Buzzers,
        Unknown,        
    }

    public class Runner
    {
        private readonly CompositionContainer _container;

        public Runner()
        {
            var catalog = new DirectoryCatalog(".");
            _container = new CompositionContainer(catalog);
            _container.ComposeParts(this);
        }

        [Import]
        private IDeviceSpace deviceSpace { get; set; }

        public void Loop()
        {
            System.Console.WriteLine("Found devices:");
            System.Console.WriteLine("{0, 20}: Description", "Name");
            var devices2 = deviceSpace.Devices;
            foreach (var device in devices2)
            {
                System.Console.WriteLine("{0, 20}: {1}", device.Name, device.Description);
            }

            var done = false;
            while (!done)
            {
                System.Console.Write("Command: ");
                var input = System.Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                input = input.Trim();
                var buffer = input.Split(' ');
                if (buffer.Length < 1) continue;

                var verb = GetVerb(buffer);
                if (verb == Verb.Unknown)
                {
                    PrintVerbs();
                    continue;
                }
                var target = GetTarget(buffer);

                switch (verb)
                {
                    case Verb.Quit:
                    case Verb.Exit:
                        StopDevices();
                        done = true;
                        break;
                    case Verb.Start:
                        //if (!string.IsNullOrEmpty(target))
                        //{
                        //    var devices = deviceSpace.Devices.Where(dev => dev.Name == target).Select(dev => target);

                        //}
                        StartDevices();
                        break;
                    case Verb.Stop:
                        StopDevices();
                        break;
                    case Verb.List:
                        if (!CheckTarget(target))
                            continue;
                        switch (target)
                        {
                            case Target.Devices:
                                System.Console.WriteLine("{0, 20}: Description", "Name");
                                var devices = deviceSpace.Devices;
                                foreach (var device in devices)
                                {
                                    System.Console.WriteLine("{0, 20}: {1}", device.Name, device.Description);
                                }
                                break;
                        }
                        break;
                }
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

        private bool CheckTarget(Target target)
        {
            if (target == Target.Unknown)
            {
                PrintTargets();
                return false;
            }
            return true;
        }

        Verb GetVerb(string[] buffer)
        {
            foreach (var str in buffer)
            {
                Verb result;
                if (Enum.TryParse(str, true, out result))
                    return result;
            }
            return Verb.Unknown;
        }

        void PrintVerbs()
        {
            System.Console.WriteLine("Known verbs:");
            foreach (var verb in Enum.GetValues(typeof(Verb)))
            {
                System.Console.WriteLine("- {0}", verb);
            }
        }

        Target GetTarget(string[] buffer)
        {
            foreach (var str in buffer)
            {
                Target result;
                if (Enum.TryParse(str, true, out result))
                    return result;
            }
            return Target.Unknown;
        }

        void PrintTargets()
        {
            System.Console.WriteLine("Known targets:");
            foreach (var target in Enum.GetValues(typeof(Target)))
            {
                System.Console.WriteLine("- {0}", target);
            }
        }
    }
}
