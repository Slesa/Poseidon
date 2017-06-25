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
        Beep, Sound, // Buzzers
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

        [Import(typeof(IDeviceSpace))]
        private IDeviceSpace deviceSpace { get; set; }

        [ImportMany(typeof(ICommands))]
        private ICommands[] _commandHandlers;

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

                var verb = CommandReader.GetVerb<Verb>(buffer);
                if (verb == null) { PrintVerbs(); continue; }

                if (verb==Verb.Quit || verb==Verb.Exit)
                {
                    StopDevices();
                    done = true;
                    continue;
                }

                Execute(buffer);

                //var target = GetTarget(buffer);
                /*
                }
                */
            }
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

        //private bool CheckTargetType(Target target, Target requested)
        //{
        //    if (target != requested)
        //    {
        //        System.Console.WriteLine("{0} is not of type {1}", target, requested);
        //        return false;
        //    }
        //    return true;
        //}

        void Execute(string[] input)
        {
            foreach (var handler in _commandHandlers)
            {
                var result = handler.Handle(input);
                if (result == Execution.Empty)
                {
                    PrintVerbs();
                    return;
                }
                if (result == Execution.Done)
                {
                    return;
                }
            }
            PrintVerbs();
        }

        private void StopDevices()
        {
            foreach (var device in deviceSpace.Devices)
                device.Stop();
        }

        void PrintVerbs()
        {
            System.Console.WriteLine("Known verbs:");
            foreach (var handler in _commandHandlers)
                handler.PrintVerbs();
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
