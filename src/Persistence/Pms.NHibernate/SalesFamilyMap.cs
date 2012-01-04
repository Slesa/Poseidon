using FluentNHibernate.Mapping;
using Pms.Model;

namespace Pms.NHibernate
{
    public class SalesFamilyMap : ClassMap<SalesFamily>
    {
        public SalesFamilyMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            Map(d => d.Name).Length(40);

            Version(d => d.Version);
        }
    }
}