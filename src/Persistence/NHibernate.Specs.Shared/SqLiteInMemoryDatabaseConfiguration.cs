using FluentNHibernate.Cfg.Db;
using Persistence.Shared;

namespace NHibernate.Specs.Shared
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