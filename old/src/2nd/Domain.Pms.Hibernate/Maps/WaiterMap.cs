using FluentNHibernate.Mapping;
using Poseidon.Domain.Pms.Model;

namespace Poseidon.Domain.Pms.Hibernate.Maps
{
    public class WaiterMap : ClassMap<Waiter>
    {
        public WaiterMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            //References(d => d.User).Not.Nullable();
            References(d => d.WaiterTeam).Not.Nullable();

            Version(d => d.Version);
        }
    }
}