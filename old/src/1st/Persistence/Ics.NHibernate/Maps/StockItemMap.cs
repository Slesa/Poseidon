using FluentNHibernate.Mapping;
using Ics.Model;

namespace Ics.NHibernate.Maps
{
    public class StockItemMap : ClassMap<StockItem>
    {
        public StockItemMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            References(d => d.Stock); // TODO: can stock of stock item be made .Not.Nullable()?
            References(d => d.RecipeableItem).Not.Nullable();
            Map(d => d.Quantity);
            References(d => d.Unit).Not.Nullable();

            Version(d => d.Version);
        }
    }
}