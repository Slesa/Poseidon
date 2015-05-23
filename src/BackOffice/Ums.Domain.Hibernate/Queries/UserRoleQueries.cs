using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using Poseidon.Common.Persistence.Contracts;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.Ums.Domain.Hibernate.Queries
{
    public class AllUserRolesQuery : IDomainQuery<IEnumerable<UserRole>>
    {
        public IEnumerable<UserRole> Execute(ISession session)
        {
            return session.Query<UserRole>();
        }
    }
}