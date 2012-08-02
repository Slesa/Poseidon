/*using Machine.Fakes;
using Machine.Specifications;
using Pms.Model.Entities;

namespace Pms.Model.Specs
{
    [Subject(typeof(CurrencyConverter))]
    public class When_converting_without_currency : WithSubject<CurrencyConverter>
    {
        Because of = () => { _result = Subject.Convert(12.34m, null); };

        It should_return_0 = () => _result.ShouldEqual(0.0m);

        static decimal _result;
    }

    [Subject(typeof(CurrencyConverter))]
    public class When_converting_with_currency_rate_of_1: WithSubject<CurrencyConverter>
    {
        Because of = () => { _result = Subject.Convert(12.34m, new Currency {Rate = 1m}); };

        It should_return_sum = () => _result.ShouldEqual(12.34m);

        static decimal _result;
    }

    [Subject(typeof(CurrencyConverter))]
    public class When_converting_with_currency_default_rate: WithSubject<CurrencyConverter>
    {
        Because of = () => { _result = Subject.Convert(12.34m, new Currency()); };

        It should_return_sum = () => _result.ShouldEqual(12.34m);

        static decimal _result;
    }
}*/