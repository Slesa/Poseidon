using FluentNHibernate.Cfg.Db;

namespace Poseidon.Common.Persistence
{
    public interface IPersistenceConfiguration
    {
        IPersistenceConfigurer GetConfiguration(); 
    }
}