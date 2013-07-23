using FluentNHibernate.Cfg;
using Poseidon.Common.Persistence;
using Poseidon.Domain.Pms.Hibernate.Maps;

namespace Poseidon.Domain.Pms.Hibernate
{
    public class PmsMappings : IMappingContributor
    {
        public void Apply(MappingConfiguration configuration)
        {
            new FluentMappingFromAssembly().WithAssembly(typeof(CurrencyMap).Assembly.CodeBase).ApplyMappings(configuration);
        }
    }
}