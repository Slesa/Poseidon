using FluentNHibernate.Cfg.Db;

namespace Poseidon.Common.Persistence.Contracts
{
    public interface IPersistenceConfiguration
    {
        IPersistenceConfigurer GetConfiguration();
    }
}