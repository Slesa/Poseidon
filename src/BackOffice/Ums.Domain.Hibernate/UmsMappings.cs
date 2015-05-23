using FluentNHibernate.Cfg;
using Poseidon.Common.Persistence;
using Poseidon.Common.Persistence.Contracts;
using Poseidon.Ums.Domain.Hibernate.Maps;

namespace Poseidon.Ums.Domain.Hibernate
{
    public class UmsMappings : IMappingContributor
    {
        public void Apply(MappingConfiguration configuration)
        {
            new FluentMappingFromAssembly().WithAssembly(typeof(UserRoleMap).Assembly.CodeBase).ApplyMappings(configuration);
        }
    }
}