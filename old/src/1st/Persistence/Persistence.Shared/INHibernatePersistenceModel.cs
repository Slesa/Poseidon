using FluentNHibernate.Cfg;

namespace Persistence.Shared
{
    public interface INHibernatePersistenceModel
    {
        void AddMappings(MappingConfiguration configuration);
    }
}