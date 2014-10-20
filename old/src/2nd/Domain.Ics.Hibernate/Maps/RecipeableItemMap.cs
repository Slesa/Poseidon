using FluentNHibernate.Mapping;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.Domain.Ics.Hibernate.Maps
{
    public class RecipeableItemMap : ClassMap<RecipeableItem>
    {
        public RecipeableItemMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            Map(d => d.Name).Length(50);
            References(d => d.RecipeUnit).Not.Nullable();

            Version(d => d.Version);

            DiscriminateSubClassesOnColumn("type");
        }
    }
}