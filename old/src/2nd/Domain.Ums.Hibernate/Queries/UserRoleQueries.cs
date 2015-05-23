using System.Collections.Generic;
using NHibernate;
using Poseidon.Common.Persistence;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.Domain.Ums.Hibernate.Queries
{
    public class AllUserRolesQuery : IDomainQuery<IEnumerable<UserRole>>
    {
        public IEnumerable<UserRole> Execute(ISession session)
        {
            throw new System.NotImplementedException();
        }
    }
}