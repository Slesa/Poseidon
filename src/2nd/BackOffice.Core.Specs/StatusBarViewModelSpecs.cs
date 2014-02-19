using Machine.Fakes;
using Machine.Specifications;
using Microsoft.Practices.Prism.Events;
using Poseidon.BackOffice.Core.ViewModels;
using Poseidon.Common.Prism;

namespace Poseidon.BackOffice.Core.Specs
{
    [Subject(typeof(StatusBarViewModel))]
    internal class When_creating_new_statusbar_viewmodel : StatusBarViewModelSpecBase
    {
        It should_have_empty_message = () => Subject.Message.ShouldBeNull();
    }


    [Subject(typeof(StatusBarViewModel))]
    internal class When_changing_message_in_statusbar_viewmodel : StatusBarViewModelSpecBase
    {
        Establish context = () =>
            {
                Subject.PropertyChanged += (sender, args) =>
                    {
                        _propertyName = args.PropertyName;
                    };
            };

        Because of = () => Subject.Message = NewMessage;

        It should_raise_property_changed_event = () => _propertyName.ShouldEqual("Message");
        It should_change_message = () => Subject.Message.ShouldEqual(NewMessage);
        
        static string _propertyName;
        const string NewMessage = "New Message";
    }


    [Subject(typeof(StatusBarViewModel))]
    internal class When_sending_show_message_event_to_statusbar_viewmodel : StatusBarViewModelSpecBase
    {
        Establish context = () =>
            {
                Subject.PropertyChanged += (sender, args) =>
                    {
                        _propertyName = args.PropertyName;
                    };
            };

        Because of = () => EventAggregator.GetEvent<ShowMessageEvent>().Publish(NewMessage);

        It should_raise_property_changed_event = () => _propertyName.ShouldEqual("Message");
        It should_change_message = () => Subject.Message.ShouldEqual(NewMessage);
        
        static string _propertyName;
        const string NewMessage = "New Message";
    }


    [Subject(typeof(StatusBarViewModel))]
    internal class When_sending_clear_message_event_to_statusbar_viewmodel : StatusBarViewModelSpecBase
    {
        Establish context = () =>
            {
                Subject.Message = NewMessage;
            };

        Because of = () => EventAggregator.GetEvent<ClearMessageEvent>().Publish(0);

        It should_reset_message = () => Subject.Message.ShouldBeNull();
        
        const string NewMessage = "New Message";
    }



    [Subject(typeof(StatusBarViewModel))]
    internal class StatusBarViewModelSpecBase : WithFakes
    {
        Establish context = () =>
            {
                EventAggregator = new EventAggregator();
                Subject = new StatusBarViewModel(EventAggregator);
            };

        protected static EventAggregator EventAggregator;
        protected static StatusBarViewModel Subject;
    }
}