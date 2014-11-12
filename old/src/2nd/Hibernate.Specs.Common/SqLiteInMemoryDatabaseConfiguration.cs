using FluentNHibernate.Cfg.Db;
using Poseidon.Common.Persistence;

namespace Poseidon.Hibernate.Specs.Common
{
    public class SqLiteInMemoryDatabaseConfiguration : IPersistenceConfiguration
    {
        public IPersistenceConfigurer GetConfiguration()
        {
            return SQLiteConfiguration
                .Standard
                .InMemory()
                .ShowSql();
            //.ProxyFasctoryFactory
        }
    }
}