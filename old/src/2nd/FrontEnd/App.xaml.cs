using System.Windows;

namespace Poseidon.FrontEnd
{
    public partial class App : Application
    {
        void OnApplicationStartup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }
    }
}
