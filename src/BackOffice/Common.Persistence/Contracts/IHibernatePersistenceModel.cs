
using FluentNHibernate.Cfg;

namespace Poseidon.Common.Persistence.Contracts
{
    public interface IHibernatePersistenceModel
    {
        void AddMappings(MappingConfiguration configuration);
    }
}