using FluentNHibernate.Cfg;

namespace Common.Persistence.Contracts
{
    public interface IMappingContributor
    {
        void Apply(MappingConfiguration configuration);
    }
}