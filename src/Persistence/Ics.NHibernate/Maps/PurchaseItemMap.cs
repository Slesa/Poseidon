using FluentNHibernate.Mapping;
using Ics.Model;

namespace Ics.NHibernate.Maps
{
    public class PurchaseItemMap : SubclassMap<PurchaseItem>
    {
        public PurchaseItemMap()
        {
            References(d => d.PurchaseFamily).Not.Nullable();
            References(d => d.PurchaseUnit).Not.Nullable();
        }
    }
}