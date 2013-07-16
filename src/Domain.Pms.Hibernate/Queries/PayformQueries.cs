using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Pms.Model;

namespace Poseidon.Domain.Pms.Hibernate.Queries
{
    public class AllPayformsQuery : IDomainQuery<IEnumerable<Payform>>
    {
        public IEnumerable<Payform> Execute(ISession session)
        {
            return session.Query<Payform>();
        }
    }
}