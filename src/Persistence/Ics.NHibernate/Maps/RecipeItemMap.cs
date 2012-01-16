using FluentNHibernate.Mapping;
using Ics.Model;

namespace Ics.NHibernate.Maps
{
    public class RecipeItemMap : ClassMap<RecipeItem>
    {
        public RecipeItemMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            References(d => d.Recipe); // TODO: can recipe of recipe item be made .Not.Nullable()?
            References(d => d.RecipeableItem).Not.Nullable();
            Map(d => d.Quantity);
            References(d => d.Unit).Not.Nullable();

            Version(d => d.Version);
        }
    }
}