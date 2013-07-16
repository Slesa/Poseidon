using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Pms.Model;

namespace Poseidon.Domain.Pms.Hibernate.Queries
{
    public class AllSalesFamilyGroupsQuery : IDomainQuery<IEnumerable<SalesFamilyGroup>>
    {
        public IEnumerable<SalesFamilyGroup> Execute(ISession session)
        {
            return session.Query<SalesFamilyGroup>();
        }
    }
}