using System;
using Machine.Fakes;
using Machine.Specifications;
using Pms.Business.Models;
using Pms.Business.Services;

namespace Pms.Business.Specs
{
    [Subject(typeof(TableProvider))]
    class When_opening_table_with_invalid_table_id : WithSubject<TableProvider>
    {
        Because of = () => _error = Catch.Exception(() => Subject.OpenTable(0));

        It should_fail = () => _error.ShouldBeOfExactType(typeof(InvalidTableIdException));

        static Exception _error;
    }


    [Subject(typeof(TableProvider))]
    class When_opening_table_with_invalid_party_id : WithSubject<TableProvider>
    {
        Because of = () => _error = Catch.Exception(() => Subject.OpenTable(1,0));

        It should_fail = () => _error.ShouldBeOfExactType(typeof(InvalidPartyException));

        static Exception _error;
    }


    [Subject(typeof(TableProvider))]
    class When_opening_table : WithSubject<TableProvider>
    {
        Because of = () => _posTable = Subject.OpenTable(42, 43);

        It should_set_table_id = () => _posTable.TableId.ShouldEqual<uint>(42);
        It should_set_party = () => _posTable.Party.ShouldEqual<uint>(43);

        static PmsTable _posTable;
    }


    [Subject(typeof(TableProvider))]
    class When_closing_table_with_invalid_handle : WithSubject<TableProvider>
    {
        Because of = () => _error = Catch.Exception(() => Subject.CloseTable(null));

        It should_fail = () => _error.ShouldBeOfExactType(typeof(InvalidTableException));

        static Exception _error;
    }
}