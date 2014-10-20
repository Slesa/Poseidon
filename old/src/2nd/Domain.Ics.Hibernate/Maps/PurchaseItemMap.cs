using FluentNHibernate.Mapping;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.Domain.Ics.Hibernate.Maps
{
    public class PurchaseItemMap : SubclassMap<PurchaseItem>
    {
        public PurchaseItemMap()
        {
            References(d => d.PurchaseFamily);
            References(d => d.PurchaseUnit);
        }
    }
}