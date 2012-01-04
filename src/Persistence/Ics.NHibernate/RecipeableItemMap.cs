using FluentNHibernate.Mapping;
using Ics.Model;

namespace Ics.NHibernate
{
    public class RecipeableItemMap : ClassMap<RecipeableItem>
    {
        public RecipeableItemMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            Map(d => d.Name).Length(40);
            References(d => d.RecipeUnit).Not.Nullable();

            Version(d => d.Version);

            DiscriminateSubClassesOnColumn("type");
        }
    }
}