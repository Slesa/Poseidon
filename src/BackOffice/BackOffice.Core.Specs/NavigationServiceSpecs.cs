using System;
using Machine.Fakes;
using Machine.Specifications;
using Poseidon.BackOffice.Core.Services;

namespace Poseidon.BackOffice.Core.Specs
{
    [Subject(typeof(NavigationService))]
    internal class When_creating_navigation_service : NavigationServiceSpecBase
    {
        It should_have_no_current_page = () => Subject.CurrentPage.ShouldEqual(Subject.StartPage);
        It should_start_with_modules_view = () => Subject.StartPage.ToString().ShouldEqual(Module);
        It should_not_enable_home = () => Subject.CanGoHome.ShouldBeFalse();
        It should_not_enable_back = () => Subject.CanGoBack.ShouldBeFalse();
        It should_not_enable_forward = () => Subject.CanGoForward.ShouldBeFalse();
    }


    [Subject(typeof(NavigationService))]
    internal class When_navigating_to_page : NavigationServiceSpecBase
    {
        Because of = () => Subject.ReportNavigation(FirstPage);

        It should_not_change_start_view = () => Subject.StartPage.ToString().ShouldEqual(Module);
        It should_have_current_page = () => Subject.CurrentPage.ShouldEqual(FirstPage);
        It should_enable_home = () => Subject.CanGoHome.ShouldBeTrue();
        It should_enable_back = () => Subject.CanGoBack.ShouldBeTrue();
        It should_not_enable_forward = () => Subject.CanGoForward.ShouldBeFalse();
    }


    [Subject(typeof(NavigationService))]
    internal class When_navigating_to_page_and_back : NavigationServiceSpecBase
    {
        Because of = () =>
            {
                Subject.ReportNavigation(FirstPage);
                Subject.ReportNavigation(Subject.GoBackOnePage());
            };

        It should_have_start_page_as_current_page = () => Subject.CurrentPage.ToString().ShouldEqual(Module);
        It should_not_enable_back = () => Subject.CanGoBack.ShouldBeFalse();
        It should_enable_forward = () => Subject.CanGoForward.ShouldBeTrue();
    }


    [Subject(typeof(NavigationService))]
    internal class When_navigating_to_page_and_back_and_forward : NavigationServiceSpecBase
    {
        Because of = () =>
            {
                Subject.ReportNavigation(FirstPage);
                Subject.ReportNavigation(Subject.GoBackOnePage());
                Subject.ReportNavigation(Subject.GoForwardOnePage());
            };

        It should_have_current_page = () => Subject.CurrentPage.ShouldEqual(FirstPage);
        It should_enable_back = () => Subject.CanGoBack.ShouldBeTrue();
        It should_not_enable_forward = () => Subject.CanGoForward.ShouldBeFalse();
    }


    [Subject(typeof(NavigationService))]
    internal class When_navigating_to_two_pages_and_back : NavigationServiceSpecBase
    {
        Because of = () =>
            {
                Subject.ReportNavigation(FirstPage);
                Subject.ReportNavigation(SecondPage);
                Subject.ReportNavigation(Subject.GoBackOnePage());
            };

        It should_have_first_page_as_current_page = () => Subject.CurrentPage.ShouldEqual(FirstPage);
        It should_enable_back = () => Subject.CanGoBack.ShouldBeTrue();
        It should_enable_forward = () => Subject.CanGoForward.ShouldBeTrue();
    }


    [Subject(typeof(NavigationService))]
    internal class When_navigating_to_page_and_back_then_to_other_page : NavigationServiceSpecBase
    {
        Because of = () =>
            {
                Subject.ReportNavigation(FirstPage);
                Subject.ReportNavigation(Subject.GoBackOnePage());
                Subject.ReportNavigation(SecondPage);
            };

        It should_have_second_page_as_current_page = () => Subject.CurrentPage.ShouldEqual(SecondPage);
        It should_enable_back = () => Subject.CanGoBack.ShouldBeTrue();
        It should_disable_forward = () => Subject.CanGoForward.ShouldBeFalse();
    }


    [Subject(typeof(NavigationService))]
    internal class When_navigating_to_page_and_then_home : NavigationServiceSpecBase
    {
        Because of = () =>
            {
                Subject.ReportNavigation(FirstPage);
                Subject.ReportNavigation(Subject.GoHome());
            };

        It should_have_second_page_as_current_page = () => Subject.CurrentPage.ShouldEqual(SecondPage);
        It should_enable_back = () => Subject.CanGoBack.ShouldBeTrue();
        It should_disable_forward = () => Subject.CanGoForward.ShouldBeFalse();
    }



    [Subject(typeof(NavigationService))]
    internal class NavigationServiceSpecBase : WithSubject<NavigationService>
    {
        protected static Uri FirstPage = new Uri("FirstPage", UriKind.Relative);
        protected static Uri SecondPage = new Uri("SecondPage", UriKind.Relative);

        protected const string Module = "ModulesView";
    }
}