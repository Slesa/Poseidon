using Pms.Model.Entities;

namespace Pms.Model
{
    public class CurrencyConverter : IConvertCurrencies
    {
        public decimal Convert(decimal sum, Currency currency)
        {
            if( currency==null)
                return 0m;
            return sum*currency.Rate;
        }
    }
}