using FluentNHibernate.Mapping;
using Ics.Model;

namespace Ics.NHibernate
{
    public class PurchaseFamilyMap : ClassMap<PurchaseFamily>
    {
        public PurchaseFamilyMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            Map(d => d.Name).Length(40);

            Version(d => d.Version);
        }
    }
}