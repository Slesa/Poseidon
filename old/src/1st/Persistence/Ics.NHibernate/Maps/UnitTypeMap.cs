using FluentNHibernate.Mapping;
using Ics.Model;

namespace Ics.NHibernate.Maps
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
