using FluentNHibernate.Cfg;

namespace Persistence.Shared
{
    public interface IMappingContributor
    {
        void Apply(MappingConfiguration configuration);
    }
}