using FluentNHibernate.Mapping;
using Pms.Model.Entities;

namespace Pms.NHibernate.Maps
{
    public class DiscountMap : ClassMap<Discount>
    {
        public DiscountMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            Map(d => d.Name).Length(40);
            Map(d => d.Rate).Default("1.0");
            Map(d => d.IsAbsolute);
            Map(d => d.UseForOrders);
            Map(d => d.UseForSale);

            Version(d => d.Version);
        }
    }
}