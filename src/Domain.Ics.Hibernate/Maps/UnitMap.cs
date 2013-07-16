using FluentNHibernate.Mapping;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.Domain.Ics.Hibernate.Maps
{
    public class UnitMap : ClassMap<Unit>
    {
        public UnitMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            Map(d => d.Name).Length(40);
            Map(d => d.Contraction).Length(15);
            References(d => d.UnitType).Not.Nullable();
            References(d => d.Parent);
            Map(d => d.FactorToParent).Default("1.0");
            Map(d => d.ForPurchase);
            Map(d => d.ForRecipe);

            Version(d => d.Version);
        }
    }
}