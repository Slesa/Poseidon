using FluentNHibernate.Mapping;
using Poseidon.Domain.Pms.Model;

namespace Poseidon.Domain.Pms.Hibernate.Maps
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