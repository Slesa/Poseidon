using Pms.Model.Entities;

namespace Pms.Model
{
    public interface IConvertCurrencies
    {
        decimal Convert(decimal sum, Currency currency);
    }
}