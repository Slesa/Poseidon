using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Pms.Model;

namespace Poseidon.Domain.Pms.Hibernate.Queries
{
    public class AllDiscountsQuery : IDomainQuery<IEnumerable<Discount>>
    {
        public IEnumerable<Discount> Execute(ISession session)
        {
            return session.Query<Discount>();
        }
    }
}