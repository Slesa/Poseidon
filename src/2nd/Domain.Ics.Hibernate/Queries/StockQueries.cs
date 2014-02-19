using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.Domain.Ics.Hibernate.Queries
{
    public class AllStocksQuery : IDomainQuery<IEnumerable<Stock>>
    {
        public IEnumerable<Stock> Execute(ISession session)
        {
            return session.Query<Stock>();
        }
    }
}