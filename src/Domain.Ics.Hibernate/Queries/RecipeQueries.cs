using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.Domain.Ics.Hibernate.Queries
{
    public class AllRecipesQuery : IDomainQuery<IEnumerable<Recipe>>
    {
        public IEnumerable<Recipe> Execute(ISession session)
        {
            return session.Query<Recipe>();
        }
    }
}