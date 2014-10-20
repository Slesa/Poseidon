using FluentNHibernate.Mapping;
using Pms.Model.Entities;

namespace Pms.NHibernate.Maps
{
    public class CurrencyMap : ClassMap<Currency>
    {
        public CurrencyMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            Map(d => d.Name).Length(40);
            Map(d => d.Contraction).Length(10);
            Map(d => d.Symbol).Length(3);
            Map(d => d.Rate).Default("1.0");
            Map(d => d.DecimalChar);
            Map(d => d.DecimalPosition);
            Map(d => d.ThousandChar);

            Version(d => d.Version);
        }
    }
}
