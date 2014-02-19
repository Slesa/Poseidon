using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.Domain.Ics.Hibernate.Queries
{
    public class AllRecipeableItemsQuery : IDomainQuery<IEnumerable<RecipeableItem>>
    {
        public IEnumerable<RecipeableItem> Execute(ISession session)
        {
            return session.Query<RecipeableItem>();
        }
    }
}