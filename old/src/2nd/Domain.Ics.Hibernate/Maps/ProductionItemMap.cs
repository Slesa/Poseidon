using FluentNHibernate.Mapping;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.Domain.Ics.Hibernate.Maps
{
    public class ProductionItemMap : SubclassMap<ProductionItem>
    {
        public ProductionItemMap()
        {
            HasMany(d => d.RecipeItems)
                .Access.CamelCaseField(Prefix.Underscore)
                .Cascade.AllDeleteOrphan();
        }
    }
}