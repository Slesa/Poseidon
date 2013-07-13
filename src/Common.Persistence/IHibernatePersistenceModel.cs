using FluentNHibernate.Cfg;

namespace Poseidon.Common.Persistence
{
    public interface IHibernatePersistenceModel
    {
        void AddMappings(MappingConfiguration configuration);
    }
}