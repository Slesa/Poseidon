using FluentNHibernate.Cfg;

namespace Poseidon.Common.Persistence.Contracts
{
    public interface IMappingContributor
    {
        void Apply(MappingConfiguration configuration);
    }
}