using System;
using Machine.Fakes;
using Machine.Specifications;
using Pms.Business.Models;
using Pms.Business.Services;
using Pms.Model;
using Poseidon.Common.Persistence;

namespace Pms.Business.Specs
{
    [Subject(typeof(TerminalProvider))]
    class When_claiming_terminal_with_invalid_id : WithSubject<TerminalProvider>
    {
        Because of = () => _error = Catch.Exception(() => Subject.ClaimTerminal(0));
        
        It should_fail = () => _error.ShouldBeOfExactType(typeof (InvalidTerminalIdException));
        
        static Exception _error; 
    }


    [Subject(typeof (TerminalProvider))]
    class When_claiming_unknown_terminal : WithSubject<TerminalProvider>
    {
        Establish context = () => Subject.DbConversation = An<IDbConversation>();

        Because of = () => _error = Catch.Exception(() => Subject.ClaimTerminal(42));

        It should_fail = () => _error.ShouldBeOfExactType(typeof (TerminalNotFoundException));
        
        static Exception _error; 
    }


    [Subject(typeof(TerminalProvider))]
    class When_claiming_terminal : WithSubject<TerminalProvider>
    {
        Establish context = () =>
            {
                _terminal = new Terminal();
                var dbConverstion = An<IDbConversation>();
                dbConverstion.WhenToldTo(x=>x.GetById<Terminal>(Param<uint>.IsAnything)).Return(_terminal);
                Subject.DbConversation = dbConverstion;
            };

        Because of = () => _posTerminal = Subject.ClaimTerminal(42);

        It should_set_terminal = () => _posTerminal.Terminal.ShouldEqual(_terminal);

        static Terminal _terminal;
        static PmsTerminal _posTerminal;
    }


    [Subject(typeof(TerminalProvider))]
    class When_freeing_terminal_with_invalid_handle : WithSubject<TerminalProvider>
    {
        Because of = () => _error = Catch.Exception(() => Subject.FreeTerminal(null));

        It should_fail = () => _error.ShouldBeOfExactType(typeof(InvalidTerminalException));

        static Exception _error;
    }


}