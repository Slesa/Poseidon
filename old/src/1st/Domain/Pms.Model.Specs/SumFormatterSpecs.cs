/*using System.Globalization;
using Machine.Fakes;
using Machine.Specifications;
using Pms.Model.Entities;

namespace Pms.Model.Specs
{/*
    [Subject(typeof(SumFormatter))]
    public class When_formatting_without_currency : WithSubject<SumFormatter>
    {
        const decimal Sum = 123478.90m;

        Because of = () =>
            {
                _result = Subject.Format(Sum, null);
                _compare = Sum.ToString("C", CultureInfo.CurrentCulture);
            };

        It should_equal_current_culture_formatting = () => _result.ShouldEqual(_compare);

        static string _result;
        static string _compare;
    }

    [Subject(typeof(SumFormatter))]
    public class When_formating_with_currency : WithSubject<SumFormatter>
    {
        const decimal Sum = 123478.90m;


        Because of = () =>
            {
                _result = Subject.Format(Sum, new Currency {Symbol = "#", DecimalChar = '-', ThousandChar = ':'});
            };

        It should_equal_current_culture_formatting = () => _result.ShouldEqual("12:345:678-90");

        static string _result;
    }
}*/
