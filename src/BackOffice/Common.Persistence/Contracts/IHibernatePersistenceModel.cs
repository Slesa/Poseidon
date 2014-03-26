
using FluentNHibernate.Cfg;

namespace Common.Persistence.Contracts
{
    public interface IHibernatePersistenceModel
    {
        void AddMappings(MappingConfiguration configuration);
    }
}