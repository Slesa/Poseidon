using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Pms.Model;

namespace Poseidon.Domain.Pms.Hibernate.Queries
{
    public class AllSalesFamiliesQuery : IDomainQuery<IEnumerable<SalesFamily>>
    {
        public IEnumerable<SalesFamily> Execute(ISession session)
        {
            return session.Query<SalesFamily>();
        }
    }
}