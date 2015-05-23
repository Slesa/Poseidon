using FluentNHibernate.Mapping;
using Pms.Model.Entities;

namespace Pms.NHibernate.Maps
{
    public class SalesFamilyMap : ClassMap<SalesFamily>
    {
        public SalesFamilyMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            Map(d => d.Name).Length(40);
            References(d => d.SalesFamilyGroup).Not.Nullable();

            Version(d => d.Version);
        }
    }
}