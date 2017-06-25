using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Devices.Core.Contracts;

namespace Devices.Test.Console
{
    [Export(typeof(ICommands))]
    public class BuzzerCommands : ICommands
    {
        [Import(typeof(IDeviceSpace))]
        private IDeviceSpace deviceSpace { get; set; }

        enum Verbs
        {
            Beep,
            Sound
        }

        public Execution Handle(string[] input)
        {
            var verb = CommandReader.GetVerb<Verbs>(input);
            if (verb == null) return Execution.Empty;

            IEnumerable<IBuzzer> buzzers;
            switch (verb)
            {
                case Verbs.Beep:
                    //if (!CheckTarget(target))
                    //    continue;
                    //if (!CheckTargetType(target, Target.Buzzers)) continue;
                    buzzers = deviceSpace.Buzzers;
                    foreach (var buzzer in buzzers)
                    {
                        buzzer.Beep();
                    }
                    break;
                case Verbs.Sound:
                    //if (!CheckTarget(target))
                    //    continue;
                    //if (!CheckTargetType(target, Target.Buzzers)) continue;
                    buzzers = deviceSpace.Buzzers;
                    foreach (var buzzer in buzzers)
                    {
                        buzzer.Sound(5, 200);
                    }
                    break;
            }
            return Execution.Skip;
        }


        public void PrintVerbs()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Buzzer commands:");
            foreach (var verb in Enum.GetValues(typeof(Verbs)))
            {
                System.Console.WriteLine("- {0}", verb);
            }
        }

    }
}