using FluentNHibernate.Mapping;
using Pms.Model;

namespace Pms.NHibernate
{
    public class PayformMap : ClassMap<Payform>
    {
        public PayformMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            Map(d => d.Name).Length(40);

            Version(d => d.Version);
        }
    }
}