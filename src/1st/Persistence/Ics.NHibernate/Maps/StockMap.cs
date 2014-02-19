using FluentNHibernate.Mapping;
using Ics.Model;

namespace Ics.NHibernate.Maps
{
    public class StockMap : ClassMap<Stock>
    {
        public StockMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            Map(d => d.Name).Length(40);
            Map(d => d.IsMainStock);
            HasMany(d => d.StockItems)
                .Access.CamelCaseField(Prefix.Underscore)
                .Cascade.AllDeleteOrphan();

            Version(d => d.Version);
        }
    }
}