using Pms.Model.Entities;

namespace Pms.Model
{
    public interface IFormatSums
    {
        string Format(decimal sum, Currency currency);
    }
}