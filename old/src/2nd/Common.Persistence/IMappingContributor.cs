using FluentNHibernate.Cfg;

namespace Poseidon.Common.Persistence
{
    public interface IMappingContributor
    {
        void Apply(MappingConfiguration configuration);
    }
}