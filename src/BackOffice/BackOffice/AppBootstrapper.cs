﻿using System;
using System.Collections.Generic;
using System.Windows.Input;
using BackOffice.Input;
using BackOffice.ViewModels;
using Caliburn.Micro;
using LightCore;
using LightCore.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;

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

            ServiceLocator.SetLocatorProvider(() => new LightCoreAdapter(_container));

            ConfigureKeyTrigger();
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

        void ConfigureKeyTrigger()
        {
            var trigger = Parser.CreateTrigger;

            Parser.CreateTrigger = (target, triggerText) =>
                {
                    if (triggerText == null)
                    {
                        var defaults = ConventionManager.GetElementConvention(target.GetType());
                        return defaults.CreateTrigger();
                    }

                    var triggerDetail = triggerText
                        .Replace("[", string.Empty)
                        .Replace("]", string.Empty);

                    var modifiers = ModifierKeys.None;
                    var key = Key.None;
                    var options = triggerDetail.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var option in options)
                    {
                        var splits = option.Split((char[]) null, StringSplitOptions.RemoveEmptyEntries);
                        if (splits[0].Trim().ToLower() == "key")
                        {
                            key = (Key) Enum.Parse(typeof (Key), splits[1], true);
                            continue;
                        }
                        if (splits[0].Trim().ToLower() == "modifiers")
                        {
                            for (var i = 1; i < splits.Length; i++)
                            {
                                var modifier = (ModifierKeys) Enum.Parse(typeof (ModifierKeys), splits[i], true);
                                if (modifier != null) modifiers |= modifier;
                            }
                        }
                    }
                    return key != Key.None
                               ? new KeyTrigger {Key = key, Modifiers = modifiers}
                               : trigger(target, triggerText);
                };
        }
    }
}