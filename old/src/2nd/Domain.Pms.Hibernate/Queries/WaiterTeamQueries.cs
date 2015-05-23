using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Pms.Model;

namespace Poseidon.Domain.Pms.Hibernate.Queries
{
    public class AllWaiterTeamsQuery : IDomainQuery<IEnumerable<WaiterTeam>>
    {
        public IEnumerable<WaiterTeam> Execute(ISession session)
        {
            return session.Query<WaiterTeam>();
        }
    }
}