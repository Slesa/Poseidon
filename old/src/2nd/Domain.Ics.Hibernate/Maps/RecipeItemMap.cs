using FluentNHibernate.Mapping;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.Domain.Ics.Hibernate.Maps
{
    public class RecipeItemMap : ClassMap<RecipeItem>
    {
        public RecipeItemMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            References(d => d.Recipe);
            References(d => d.RecipeableItem);
            Map(d => d.Quantity);
            References(d => d.Unit);

            Version(d => d.Version);
        }
    }
}