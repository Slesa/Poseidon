using System;
using Machine.Fakes;
using Machine.Specifications;
using Pms.Business.Models;
using Pms.Business.Services;
using Pms.Model;
using Poseidon.Common.Persistence;

namespace Pms.Business.Specs
{
    [Subject(typeof(WorkbenchProvider))]
    class When_claiming_workbench_with_invalid_id : WithSubject<WorkbenchProvider>
    {
        Because of = () => _error = Catch.Exception(() => Subject.ClaimWorkbench(0));

        It should_fail = () => _error.ShouldBeOfExactType(typeof(InvalidWaiterIdException));

        static Exception _error;
    }


    [Subject(typeof (WorkbenchProvider))]
    class When_claiming_workbench_with_unknown_waiter : WithSubject<WorkbenchProvider>
    {
        Establish context = () => Subject.DbConversation = An<IDbConversation>();

        Because of = () => _error = Catch.Exception(() => Subject.ClaimWorkbench(42));

        It should_fail = () => _error.ShouldBeOfExactType(typeof(WaiterNotFoundException));

        static Exception _error;
    }


    [Subject(typeof(WorkbenchProvider))]
    class When_claiming_workbench : WithSubject<WorkbenchProvider>
    {
        Establish context = () =>
            {
                _waiter = new Waiter();
                var dbConverstion = An<IDbConversation>();
                dbConverstion.WhenToldTo(x => x.GetById<Waiter>(Param<uint>.IsAnything)).Return(_waiter);
                Subject.DbConversation = dbConverstion;
            };

        Because of = () => _workbench = Subject.ClaimWorkbench(42);

        It should_set_waiter = () => _workbench.Waiter.ShouldEqual(_waiter);

        static PmsWorkbench _workbench;
        static Waiter _waiter;
    }


    [Subject(typeof(WorkbenchProvider))]
    class When_freeing_workbench_with_invalid_handle : WithSubject<WorkbenchProvider>
    {
        Because of = () => _error = Catch.Exception(() => Subject.FreeWorkbench(null));

        It should_fail = () => _error.ShouldBeOfExactType(typeof(InvalidWorkbenchException));

        static Exception _error;
    }
}