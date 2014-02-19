using FluentNHibernate.Mapping;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.Domain.Ics.Hibernate.Maps
{
    public class StockItemMap : ClassMap<StockItem>
    {
        public StockItemMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            References(d => d.Stock);
            References(d => d.RecipeableItem);
            Map(d => d.Quantity);
            References(d => d.Unit);

            Version(d => d.Version);
        }
    }
}