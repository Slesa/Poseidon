using FluentNHibernate.Cfg.Db;

namespace Common.Persistence.Contracts
{
    public interface IPersistenceConfiguration
    {
        IPersistenceConfigurer GetConfiguration();
    }
}