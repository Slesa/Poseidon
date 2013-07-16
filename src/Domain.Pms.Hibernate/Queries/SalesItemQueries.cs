using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Pms.Model;

namespace Poseidon.Domain.Pms.Hibernate.Queries
{
    public class AllSalesItemsQuery : IDomainQuery<IEnumerable<SalesItem>>
    {
        public IEnumerable<SalesItem> Execute(ISession session)
        {
            return session.Query<SalesItem>();
        }
    }
}