﻿using BackOffice.Core.Contracts;
using BackOffice.Core.ViewModels;
using Caliburn.Micro;
using Machine.Fakes;
using Machine.Specifications;

namespace BackOffice.Core.Specs
{
    [Subject(typeof(StatusBarViewModel))]
    internal class When_creating_new_statusbar_viewmodel : StatusBarViewModelSpecBase
    {
        It should_have_empty_message = () => Subject.Message.ShouldBeEmpty();
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

        Because of = () => EventAggregator.Publish(new StatusBarMessageEvent(Message));

        It should_raise_property_changed_event = () => _propertyName.ShouldEqual("Message");
        It should_change_message = () => Subject.Message.ShouldEqual(Message);

        static string _propertyName;
        const string Message = "New Message";
    }


    [Subject(typeof(StatusBarViewModel))]
    internal class When_sending_clear_message_event_to_statusbar_viewmodel : StatusBarViewModelSpecBase
    {
        Establish context = () =>
            {
                Subject.Message = NewMessage;
            };

        Because of = () => EventAggregator.Publish(new StatusBarClearEvent());

        It should_reset_message = () => Subject.Message.ShouldBeEmpty();

        const string NewMessage = "New Message";
    }



    internal class StatusBarViewModelSpecBase : WithFakes
    {
        Establish context = () =>
            {
                EventAggregator = new EventAggregator();
                Subject = new StatusBarViewModel(EventAggregator);
            };

        protected static IEventAggregator EventAggregator;
        protected static StatusBarViewModel Subject;
    }
}