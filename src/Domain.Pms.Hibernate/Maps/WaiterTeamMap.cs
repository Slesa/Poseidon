using FluentNHibernate.Mapping;
using Poseidon.Domain.Pms.Model;

namespace Poseidon.Domain.Pms.Hibernate.Maps
{
    public class WaiterTeamMap : ClassMap<WaiterTeam>
    {
        public WaiterTeamMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            Map(d => d.Name).Length(40);

            Version(d => d.Version);
        }
    }
}