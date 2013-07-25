using Machine.Fakes;
using Machine.Specifications;
using Microsoft.Practices.Prism.Regions;
using Poseidon.BackOffice.Core.ViewModels;

namespace BackOffice.Core.Specs
{
    [Subject(typeof(NavigationViewModel))]
    internal class When_creating_navigation_viewmodel : NavigationViewModelSpecBase
    {
    }

    [Subject(typeof(NavigationViewModel))]
    internal class NavigationViewModelSpecBase : WithFakes
    {
        Establish context = () =>
            {
                RegionManager = An<IRegionManager>();
                Subject = new NavigationViewModel(RegionManager);
            };

        protected static IRegionManager RegionManager;
        protected static NavigationViewModel Subject;
    }
}