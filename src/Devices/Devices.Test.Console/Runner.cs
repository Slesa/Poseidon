using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Devices.Core.Contracts;

namespace Devices.Test.Console
{
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
				var commands = input.Split(' ');
				if (commands.Length < 1) continue;

				switch (commands[0])
				{
					case "quit":
					case "exit":
						done = true;
						break;
					case "devices":
						if (commands.Length < 2) break;
						switch (commands[1])
						{
							case "list":
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
    }
}
