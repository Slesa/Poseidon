using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.Domain.Ics.Hibernate.Queries
{
    public class AllProductionItemsQuery : IDomainQuery<IEnumerable<ProductionItem>>
    {
        public IEnumerable<ProductionItem> Execute(ISession session)
        {
            return session.Query<ProductionItem>();
        }
    }
}