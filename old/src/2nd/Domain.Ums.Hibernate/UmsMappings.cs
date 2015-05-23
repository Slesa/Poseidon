using FluentNHibernate.Cfg;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Ums.Hibernate.Maps;

namespace Poseidon.Domain.Ums.Hibernate
{
    public class UmsMappings : IMappingContributor
    {
        public void Apply(MappingConfiguration configuration)
        {
            new FluentMappingFromAssembly().WithAssembly(typeof(UserRoleMap).Assembly.CodeBase).ApplyMappings(configuration);
        }
    }
}