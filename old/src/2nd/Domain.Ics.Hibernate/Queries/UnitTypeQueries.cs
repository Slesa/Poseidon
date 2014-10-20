using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.Domain.Ics.Hibernate.Queries
{
    public class AllUnitTypesQuery : IDomainQuery<IEnumerable<UnitType>>
    {
        public IEnumerable<UnitType> Execute(ISession session)
        {
            return session.Query<UnitType>();
        }
    }
}