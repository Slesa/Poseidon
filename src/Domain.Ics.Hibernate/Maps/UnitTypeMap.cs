using FluentNHibernate.Mapping;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.Domain.Ics.Hibernate.Maps
{
    public class UnitTypeMap : ClassMap<UnitType>
    {
        public UnitTypeMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            Map(d => d.Name).Length(20);

            Version(d => d.Version);
        }
    }
}