using FluentNHibernate.Mapping;
using Pms.Model.Entities;

namespace Pms.NHibernate.Maps
{
    public class SalesItemMap :ClassMap<SalesItem>
    {
        public SalesItemMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            Map(d => d.Name).Length(40);
            References(d => d.SalesFamily).Not.Nullable();

            Version(d => d.Version);
        }
    }
}