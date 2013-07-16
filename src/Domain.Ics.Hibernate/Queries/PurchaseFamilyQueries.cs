using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.Domain.Ics.Hibernate.Queries
{
    public class AllPurchaseFamiliesQuery : IDomainQuery<IEnumerable<PurchaseFamily>>
    {
        public IEnumerable<PurchaseFamily> Execute(ISession session)
        {
            return session.Query<PurchaseFamily>();
        }
    }
}