using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using Persistence.Shared;
using Ums.Model;

namespace Ums.NHibernate.Queries
{
    public class AllUsersQuery : IDomainQuery<IEnumerable<User>>
    {
        public IEnumerable<User> Execute(ISession session)
        {
            return session.Query<User>();
        }
    }
}