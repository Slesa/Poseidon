﻿using System;
using System.Windows;
using System.Windows.Input;
using Caliburn.Micro;
using _06_KeyBinding.Input;

namespace _06_KeyBinding {
    public class KeyBindingBootstrapper : BootstrapperBase {
        public KeyBindingBootstrapper() {
            Start();
        }

        protected override void Configure() {
            var trigger = Parser.CreateTrigger;

            Parser.CreateTrigger = (target, triggerText) => {
                if(triggerText == null) {
                    var defaults = ConventionManager.GetElementConvention(target.GetType());
                    return defaults.CreateTrigger();
                }

                var triggerDetail = triggerText
                    .Replace("[", string.Empty)
                    .Replace("]", string.Empty);

                var splits = triggerDetail.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                if(splits[0] == "Key") {
                    var key = (Key)Enum.Parse(typeof(Key), splits[1], true);
                    return new KeyTrigger { Key = key };
                }

                return trigger(target, triggerText);
            };
        }

        protected override void OnStartup(object sender, StartupEventArgs e) {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
