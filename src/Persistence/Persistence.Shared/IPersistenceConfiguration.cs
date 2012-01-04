using FluentNHibernate.Cfg.Db;

namespace Persistence.Shared
{
    public interface IPersistenceConfiguration
    {
        IPersistenceConfigurer GetConfiguration();
    }
}