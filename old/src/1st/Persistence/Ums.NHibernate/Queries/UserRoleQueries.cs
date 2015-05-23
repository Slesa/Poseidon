using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using Persistence.Shared;
using Ums.Model;

namespace Ums.NHibernate.Queries
{
    public class AllUserRolesQuery : IDomainQuery<IEnumerable<UserRole>>
    {
        public IEnumerable<UserRole> Execute(ISession session)
        {
            return session.Query<UserRole>();
        }
    }
}
