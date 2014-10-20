using FluentNHibernate.Mapping;
using Pms.Model.Entities;

namespace Pms.NHibernate.Maps
{
    public class WaiterMap : ClassMap<Waiter>
    {
        public WaiterMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            References(d => d.WaiterTeam).Not.Nullable();

            Version(d => d.Version);
        }
    }
}