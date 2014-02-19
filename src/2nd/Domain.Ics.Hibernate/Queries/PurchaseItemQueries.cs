using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.Domain.Ics.Hibernate.Queries
{
    public class AllPurchaseItemsQuery : IDomainQuery<IEnumerable<PurchaseItem>>
    {
        public IEnumerable<PurchaseItem> Execute(ISession session)
        {
            return session.Query<PurchaseItem>();
        }
    }
}