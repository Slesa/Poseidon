using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using Poseidon.Common.Persistence.Contracts;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.Ums.Domain.Hibernate.Queries
{
    public class AllTokensQuery : IDomainQuery<IEnumerable<Token>>
    {
        public IEnumerable<Token> Execute(ISession session)
        {
            return session.Query<Token>();
        }
    }
}