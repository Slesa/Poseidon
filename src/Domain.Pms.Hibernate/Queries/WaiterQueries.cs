using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Pms.Model;

namespace Poseidon.Domain.Pms.Hibernate.Queries
{
    public class AllWaitersQuery : IDomainQuery<IEnumerable<Waiter>>
    {
        public IEnumerable<Waiter> Execute(ISession session)
        {
            return session.Query<Waiter>();
        }
    }
}