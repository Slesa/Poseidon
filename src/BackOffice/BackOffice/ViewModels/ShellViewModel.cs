using System.Windows;
using Caliburn.Micro;
using LightCore;
using Poseidon.BackOffice.Core;
using Poseidon.BackOffice.Core.Events;

namespace Poseidon.BackOffice.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IShell
        , IHandle<ActivateScreenEvent>
    {
        public ShellViewModel(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            EventAggregator = eventAggregator;
            WindowManager = windowManager;
            DisplayName = "Poseidon BackOffice";

            EventAggregator.Subscribe(this);
        }

        public IEventAggregator EventAggregator { get; private set; }
        public IWindowManager WindowManager { get; private set; }
        public IContainer Container { get; set; }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            ActivateItem(Container.Resolve<ModulesViewModel>());
        }

        public override void ActivateItem(IScreen screen)
        {
            System.Diagnostics.Debug.WriteLine("Activating " + screen.DisplayName);
            base.ActivateItem(screen);
            System.Diagnostics.Debug.WriteLine("Activated " + ActiveItem.DisplayName);
        }

        #region Commands
        
        public void DoQuit()
        {
            Application.Current.Shutdown();
        }

        #endregion

        public void Handle(ActivateScreenEvent message)
        {
            if (message.ScreenType == null) return;

            var screenView = Container.Resolve(message.ScreenType) as IScreen;
            if (screenView == null) return;
            //WindowManager.ShowDialog(screenView);

            screenView.Deactivated += (obj, args) =>
                {
                    /*var screen = message.ScreenType;
                    if (screen != null) */Items.Remove(screenView);
                };
            ActivateItem(screenView);

        }
    }
}