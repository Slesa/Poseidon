using FluentNHibernate.Mapping;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.Domain.Ics.Hibernate.Maps
{
    public class StockMap : ClassMap<Stock>
    {
        public StockMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            Map(d => d.Name).Length(50);
            Map(d => d.IsMainStock);
            HasMany(d => d.StockItems)
                .Access.CamelCaseField(Prefix.Underscore)
                .Cascade.AllDeleteOrphan();

            Version(d => d.Version);
        }
    }
}