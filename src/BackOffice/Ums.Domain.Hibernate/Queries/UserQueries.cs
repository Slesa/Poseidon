using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using Poseidon.Common.Persistence.Contracts;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.Ums.Domain.Hibernate.Queries
{
    public class AllUsersQuery : IDomainQuery<IEnumerable<User>>
    {
        public IEnumerable<User> Execute(ISession session)
        {
            return session.Query<User>();
        }
    }
}