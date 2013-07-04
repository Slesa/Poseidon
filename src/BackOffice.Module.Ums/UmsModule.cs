using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;

namespace BackOffice.Module.Ums
{
    public class UmsModule : IModule
    {
        readonly IUnityContainer _container;

        public UmsModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<UmsOfficeModule>();
        }
    }
}