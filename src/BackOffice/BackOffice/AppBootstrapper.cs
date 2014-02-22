using System;
using System.Collections.Generic;
using BackOffice.ViewModels;
using Caliburn.Micro;
using LightCore;

namespace BackOffice
{
    public class AppBootstrapper : Bootstrapper<IShell>
    {
        IContainerBuilder _builder;
        IContainer _container;

        protected override void Configure()
        {
            _builder = new ContainerBuilder();
            _builder.Register<IWindowManager, WindowManager>();
            _builder.Register<IEventAggregator, EventAggregator>();
            _builder.Register<IShell, ShellViewModel>();

            _container = _builder.Build();
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            // LightCore is able to resolve types by generics or by a type instance
            return serviceType != null ? _container.Resolve(serviceType) : null;
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.ResolveAll(serviceType);
        }

        protected override void BuildUp(object instance)
        {
            _container.InjectProperties(instance);
        }
    }
}