using FluentNHibernate.Cfg;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Ics.Hibernate.Maps;

namespace Poseidon.Domain.Ics.Hibernate
{
    public class IcsMappings : IMappingContributor 
    {
        public void Apply(MappingConfiguration configuration)
        {
            new FluentMappingFromAssembly().WithAssembly(typeof (UnitTypeMap).Assembly.CodeBase).ApplyMappings(configuration);
        }
    }
}