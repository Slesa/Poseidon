using FluentNHibernate.Mapping;
using Ics.Model;

namespace Ics.NHibernate.Maps
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