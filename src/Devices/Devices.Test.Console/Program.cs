using Devices.Core;

namespace Devices.Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var runner = new Runner();
            runner.Loop();
        }
    }
}
