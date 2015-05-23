using System.Collections.Generic;
using System.Linq;
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

    public class UserByNameQuery : IDomainQuery<User>
    {
        readonly string _userName;

        public UserByNameQuery(string userName)
        {
            _userName = userName;
        }

        public User Execute(ISession session)
        {
           return session.Query<User>().FirstOrDefault(x=>x.Name.Equals(_userName));
        }
    }
}