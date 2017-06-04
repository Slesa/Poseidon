using Devices.Core;

namespace Devices.Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var deviceSpace = new DeviceSpace();

            var done = false;
            while (!done)
            {
                System.Console.Write("Command: ");
                var input = System.Console.ReadLine();
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
