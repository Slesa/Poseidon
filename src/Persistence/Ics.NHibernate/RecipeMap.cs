using FluentNHibernate.Mapping;
using Ics.Model;

namespace Ics.NHibernate
{
    public class RecipeMap : ClassMap<Recipe>
    {
        public RecipeMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            Map(d => d.Plu);
            HasMany(d => d.RecipeItems)
                .Access.CamelCaseField(Prefix.Underscore)
                .Cascade.AllDeleteOrphan();

            Version(d => d.Version);
        }
    }
}