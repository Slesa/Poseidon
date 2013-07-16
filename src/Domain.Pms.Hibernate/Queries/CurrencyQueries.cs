using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Pms.Model;

namespace Poseidon.Domain.Pms.Hibernate.Queries
{
    public class AllCurrenciesQuery : IDomainQuery<IEnumerable<Currency>>
    {
        public IEnumerable<Currency> Execute(ISession session)
        {
            return session.Query<Currency>();
        }
    }
}